using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class SceneName : MonoBehaviour
    {
        public static string SceneNameString;
        public string currentLevel;

        void Start()
        {
            SceneNameString = currentLevel;
            AudioManager.ChangeScene = true;
        }
    }
}
