using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhysicsLagCompensation : MonoBehaviourPunCallbacks, IPunObservable
{
    Rigidbody rb;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.position);
            stream.SendNext(rb.rotation);
            stream.SendNext(rb.velocity);
        }
        else
        {
            rb.position = (Vector3)stream.ReceiveNext();
            rb.rotation = (Quaternion)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
            rb.position += rb.velocity * lag;
        }
    }

    void Awake() {
        rb = GetComponent<Rigidbody>();
        PhotonNetwork.SendRate = 30;
        PhotonNetwork.SerializationRate = 10;    
    }
}
