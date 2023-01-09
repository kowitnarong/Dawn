using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class CoinComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private CoinCount coinCount;

        private void Start()
        {

        }

        public void Interact(GameObject actor)
        {

        }

        public void ActorEnter(GameObject actor)
        {
            ItemTypeComponent itc = GetComponent<ItemTypeComponent>();
            if (itc != null)
            {
                switch (itc.Type)
                {
                    case ItemType.CoinPlus:
                        coinCount.AddCoin(1);
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