using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class CheckWin : MonoBehaviourPun
    {
        [SerializeField] private GameObject MasterWinPanel;
        [SerializeField] private GameObject ClientWinPanel;

        [Header("Scene Manager")]
        [SerializeField] private GameAppFlowManager gameAppFlowManager;
        [SerializeField] private Animator transition;
        [SerializeField] private string nextLevel;
        [SerializeField] private PunGameManager punGameManager;
        [SerializeField] private PunGameTimer punGameTimer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ball"))
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    photonView.RPC("Win", RpcTarget.AllViaServer);
                }
            }
        }

        [PunRPC]
        private void Win()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC("WinRPC", RpcTarget.Others);
                punGameTimer.StopTimer();
                MasterWinPanel.SetActive(true);
            }
            punGameManager.PauseGame(true);
            PlaySoundWin();
        }

        private void PlaySoundWin()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_win");
        }

        [PunRPC]
        private void WinRPC()
        {
            ClientWinPanel.SetActive(true);
        }

        public void onClickWin()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC("NextLevel", RpcTarget.AllViaServer);
            }
        }

        [PunRPC]
        private void NextLevel()
        {
            PunGameManager.isPause = false;
            PhotonNetwork.MinimalTimeScaleToDispatchInFixedUpdate = 1f;
            Time.timeScale = 1f;
            MasterWinPanel.SetActive(false);
            ClientWinPanel.SetActive(false);
            gameAppFlowManager.LoadSceneWithTransition(transition);
            Invoke("LoadLevelPhotonRPC", 3f);
        }

        private void LoadLevelPhotonRPC()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                photonView.RPC("LoadLevelPhoton", RpcTarget.AllViaServer, nextLevel);
            }
        }

        [PunRPC]
        public void LoadLevelPhoton(string levelName)
        {
            gameAppFlowManager.LoadLevelPhoton(levelName);
        }
    }
}