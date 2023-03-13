using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class ChangeToWinterComponent : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private ChangeCharacter changeCharacter;
        protected bool isDestroyed = false;

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
                    case ItemType.ChangeToWinter:
                        changeCharacter.ChangeCharacterWithItem(3);
                        isDestroyed = true;
                        break;
                }
            }

            DestroyObject();
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void DestroyObject()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (isDestroyed)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
            }
        }
    }
}