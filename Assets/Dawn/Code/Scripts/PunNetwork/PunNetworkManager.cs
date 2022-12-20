using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using Cinemachine;
using UnityEngine.InputSystem;

public class PunNetworkManager : ConnectAndJoinRandom
{
    public static PunNetworkManager singleton;
    public InputActionAsset _inputActions;

    private void Awake()
    {
        singleton = this;
    }
}
