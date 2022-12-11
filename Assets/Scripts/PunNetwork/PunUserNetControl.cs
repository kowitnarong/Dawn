using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformView))]
public class PunUserNetControl : MonoBehaviourPunCallbacks , IPunInstantiateMagicCallback {
    [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
    public static GameObject LocalPlayerInstance;
    public Transform CameraRoot;
    public void OnPhotonInstantiate(PhotonMessageInfo info) {
        Debug.Log(info.photonView.Owner.ToString());
        Debug.Log(info.photonView.ViewID.ToString());
        // #Important
        // used in PunNetworkManager.cs
        // : we keep track of the localPlayer instance to prevent instanciation
        // when levels are synchronized
        if (photonView.IsMine) {
            LocalPlayerInstance = gameObject;
            GetComponentInChildren<MeshRenderer>().material.color = Color.blue;

            // Reference Input on run-time
            PlayerInput _pInput = GetComponent<PlayerInput>();
        }
    }
}