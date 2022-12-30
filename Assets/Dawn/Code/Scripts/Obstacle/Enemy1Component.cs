using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class Enemy1Component : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private PlayerHP playerHP;

        private void Start()
        {

        }

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
                    case ObstacleType.hpMinus1:
                        playerHP.TakeDamage(1);
                        break;
                }
            }
            Destroy(this.gameObject, 0);
        }

        public void ActorExit(GameObject actor)
        {

        }
    }
}