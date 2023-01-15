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
            //FindObjectOfType<AudioManager>().Play("Clicked");
        }
        void PlayHover()
        {
            //FindObjectOfType<AudioManager>().Play("Hover");
        }
    }
}