using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using Cinemachine;
using UnityEngine.InputSystem;

public class PunNetworkManager : ConnectAndJoinRandom
{
    public static PunNetworkManager singleton;
    //public CinemachineVirtualCamera _vCam;
    public InputActionAsset _inputActions;

    [Header("Player Info")]
    [SerializeField] private bool _isPlayer1;
    [SerializeField] private bool _isPlayer2;
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;


    //[Tooltip("The prefab to use for representing the player")]
    //public GameObject GamePlayerPrefab;

    private void Awake()
    {
        singleton = this;
        //_player1 = GameObject.Find("Player1");
        //_player2 = GameObject.Find("Player2");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        Debug.Log("New Player. " + newPlayer.ToString());
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        if (PunUserNetControl.LocalPlayerInstance == null)
        {
            Debug.Log("We are Instantiating LocalPlayer from " +
                                               SceneManagerHelper.ActiveSceneName);
            PunNetworkManager.singleton.SpawnPlayer();
        }
        else
        {
            Debug.Log("Ignoring scene load for " +
                                               SceneManagerHelper.ActiveSceneName);
        }
    }

    public void SpawnPlayer()
    {
        
    }
}
