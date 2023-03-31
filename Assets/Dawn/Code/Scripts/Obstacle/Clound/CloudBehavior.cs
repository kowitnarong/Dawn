using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class CloudBehavior : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject dropPrefab;
        private Transform spawnArea;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnInterval = 1f;
        [SerializeField] PlayerHP playerHP;

        private void Start()
        {
            spawnArea = this.transform;
            InvokeRepeating("SpawnDrop", 0, spawnInterval);
        }

        private void SpawnDrop()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            Vector3 randomPos = new Vector3(Random.Range(-spawnArea.localScale.x / 2, spawnArea.localScale.x / 2), 0, 0);
            if (PhotonNetwork.IsMasterClient && playerHP.isGameOver == false)
                PhotonNetwork.Instantiate(dropPrefab.name, spawnPoint.position + randomPos, Quaternion.identity);
        }
    }
}
