using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RigidbodyLagCompensation : MonoBehaviourPunCallbacks, IPunObservable
{
    Rigidbody _rigidbody;

    private Vector3 _netPosition;
    private Quaternion _netRotation;
    private Vector3 _previousPos;
    private Vector3 _previousVel;

    public bool teleportIfFar;
    public float teleportIfFarDistance;

    [Header("Interpolation")]
    public float smoothPos = 5.0f;
    public float smoothRot = 5.0f;

    private void Awake()
    {
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 80;

        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_rigidbody.position);
            stream.SendNext(_rigidbody.rotation);
            stream.SendNext(_rigidbody.velocity);
        }
        else
        {
            _netPosition = (Vector3)stream.ReceiveNext();
            _netRotation = (Quaternion)stream.ReceiveNext();
            _rigidbody.velocity = (Vector3)stream.ReceiveNext();

            // Only run lag compensation if the received position or velocity has changed significantly
            if (Vector3.Distance(_previousPos, _netPosition) > 0.01f || Vector3.Distance(_previousVel, _rigidbody.velocity) > 0.01f)
            {
                float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                _netPosition += _rigidbody.velocity * lag;
            }

            _previousPos = _netPosition;
            _previousVel = _rigidbody.velocity;
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine) return;

        // Use MovePosition and MoveRotation functions to smoothly interpolate position and rotation
        _rigidbody.MovePosition(Vector3.Lerp(_rigidbody.position, _netPosition, smoothPos * Time.fixedDeltaTime));
        _rigidbody.MoveRotation(Quaternion.Lerp(_rigidbody.rotation, _netRotation, smoothRot * Time.fixedDeltaTime));

        // Only teleport if the distance between the Rigidbody's position and the received position exceeds a certain threshold
        if (Vector3.Distance(_rigidbody.position, _netPosition) > teleportIfFarDistance)
        {
            _rigidbody.position = _netPosition;
        }
    }
}