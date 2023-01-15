using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameDev4.Dawn
{
    public class ScreenResolution : MonoBehaviour
    {
        public TMP_Dropdown ResoDropdown;
        public Toggle FullScreenToggle;

        public static string ResoSelected;
        public static bool Fullscreen;

        void Start()
        {
            ResoDropdown.options.Clear();

            List<string> items = new List<string>();

            items.Add("1,366 × 768");
            items.Add("1,600 × 900");
            items.Add("1,920 × 1,080");

            foreach (var item in items)
            {
                ResoDropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
            }


            if (ResoSelected == "1,366 × 768")
            {
                ResoDropdown.value = ResoDropdown.options.FindIndex(option => option.text == "1,366 × 768");
            }
            else if (ResoSelected == "1,600 × 900")
            {
                ResoDropdown.value = ResoDropdown.options.FindIndex(option => option.text == "1,600 × 900");
            }
            else if (ResoSelected == "1,920 × 1,080")
            {
                ResoDropdown.value = ResoDropdown.options.FindIndex(option => option.text == "1,920 × 1,080");
            }

            FullScreenToggle.isOn = Fullscreen;

            ResoDropdown.onValueChanged.AddListener(delegate { DropDownSelected(ResoDropdown); });

            FullScreenToggle.onValueChanged.AddListener(delegate
            {
                ToggleValueChanged(FullScreenToggle);
            });
        }

        void DropDownSelected(TMP_Dropdown dropdown)
        {
            int index = dropdown.value;

            ResoSelected = dropdown.options[index].text;
            SetResolution();
        }

        void ToggleValueChanged(Toggle change)
        {
            Fullscreen = change.isOn;
            SetFullscreen();
        }

        void SetFullscreen()
        {
            if (Fullscreen)
            {
                switch (ResoSelected)
                {
                    case "1,366 × 768":
                        Screen.SetResolution(1366, 768, true);
                        Debug.Log("1366 * 768" + Fullscreen.ToString());
                        break;
                    case "1,600 × 900":
                        Screen.SetResolution(1600, 900, true);
                        Debug.Log("1600 * 900" + Fullscreen.ToString());
                        break;
                    case "1,920 × 1,080":
                        Screen.SetResolution(1920, 1080, true);
                        Debug.Log("1920 * 1080" + Fullscreen.ToString());
                        break;
                    default:
                        Screen.SetResolution(1366, 768, true);
                        Debug.Log("1366 * 768" + Fullscreen.ToString());
                        break;
                }
            }
            else
            {
                switch (ResoSelected)
                {
                    case "1,366 × 768":
                        Screen.SetResolution(1366, 768, false);
                        Debug.Log("1366 * 768" + Fullscreen.ToString());
                        break;
                    case "1,600 × 900":
                        Screen.SetResolution(1600, 900, false);
                        Debug.Log("1600 * 900" + Fullscreen.ToString());
                        break;
                    case "1,920 × 1,080":
                        Screen.SetResolution(1920, 1080, false);
                        Debug.Log("1920 * 1080" + Fullscreen.ToString());
                        break;
                    default:
                        Screen.SetResolution(1366, 768, false);
                        Debug.Log("1366 * 768" + Fullscreen.ToString());
                        break;
                }
            }
            //MenuScene.isSceneResoChange = true;
        }

        void SetResolution()
        {
            switch (ResoSelected)
            {
                case "1,366 × 768":
                    Screen.SetResolution(1366, 768, Fullscreen);
                    Debug.Log("1366 * 768" + Fullscreen.ToString());
                    break;
                case "1,600 × 900":
                    Screen.SetResolution(1600, 900, Fullscreen);
                    Debug.Log("1600 * 900" + Fullscreen.ToString());
                    break;
                case "1,920 × 1,080":
                    Screen.SetResolution(1920, 1080, Fullscreen);
                    Debug.Log("1920 * 1080" + Fullscreen.ToString());
                    break;
                default:
                    Screen.SetResolution(1366, 768, Fullscreen);
                    Debug.Log("1366 * 768" + Fullscreen.ToString());
                    break;
            }
            //MenuScene.isSceneResoChange = true;
        }
    }
}