using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class SpikeCanDestroyComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private PlayerHP playerHP;
        [SerializeField] private int damage = 1;

        public void Interact(GameObject actor)
        {

        }

        public void ActorEnter(GameObject actor)
        {
            ObstacleTypeComponent otc = GetComponent<ObstacleTypeComponent>();
            if (otc != null)
            {
                switch (otc.Type)
                {
                    case ObstacleType.spikeCanDestroy:
                        playerHP.TakeDamage(damage);;
                        DestroyObject();
                        break;
                }
            }
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }
}