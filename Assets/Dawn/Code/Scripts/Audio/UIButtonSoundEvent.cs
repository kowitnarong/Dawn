using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace GameDev4.Dawn
{
    public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler//, IPointerExitHandler
    {
        public void OnPointerEnter(PointerEventData ped)
        {
            PlayHover();
        }

        public void OnPointerDown(PointerEventData ped)
        {
            PlayClicked();
        }

        /*public void OnPointerExit(PointerEventData ped)
        {
            PlayHover();
        }*/

        void PlayClicked()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_UIClick");
        }
        void PlayHover()
        {
            FindObjectOfType<AudioManager>().Play("Sfx_Sfx_UIHover");
        }
    }
}