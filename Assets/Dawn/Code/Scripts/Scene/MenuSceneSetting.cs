using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class MenuSceneSetting : MonoBehaviour
    {

        private void Awake()
        {
            if (Screen.fullScreen)
            {
                ScreenResolution.Fullscreen = true;

            }
            else
            {
                ScreenResolution.Fullscreen = false;
            }
        }
    }
}
