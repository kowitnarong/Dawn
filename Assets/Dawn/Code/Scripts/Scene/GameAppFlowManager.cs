using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace GameDev4.Dawn
{
    public class GameAppFlowManager : MonoBehaviour
    {
        protected static bool IsSceneOptionsLoaded;

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        /*public void LoadMainMenu(Animator transition)
        {
            Time.timeScale = 1f;
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name != "Level1")
            {
                Score._LevelCurrent = currentScene.name;
                Score.isPlay = true;
            }
            if (currentScene.name == "SummaryScore")
            {
                if (FindObjectOfType<SummaryScore>().m_textStar != "0 Star")
                {
                    Score._LevelCurrent = "Level" + (Int32.Parse(Score._Level.Substring(5, 1)) + 1).ToString();
                    Score.isPlay = true;
                }
                else
                {
                    Score._LevelCurrent = Score._Level;
                    if (Score._Level != "Level1")
                    {
                        Score.isPlay = true;
                    }
                    else
                    {
                        Score.isPlay = false;
                    }
                }
            }
            transition.SetBool("End", true);
            Invoke("LoadSceneMenu", 3f);
        }*/

        /*public void LoadSceneStartGame(Animator transition)
        {
            if (Score.isPlay)
            {
                transition.SetBool("End", true);
                Invoke("LoadSceneStartDelay", 3f);
            }
            else
            {
                SceneManager.LoadScene("PlayerSelect", LoadSceneMode.Single);
            }
        }*/

        public void BackToMenu(Animator transition)
        {
            transition.SetBool("End", true);
            Invoke("LoadSceneMenu", 2f);
        }

        /*private void LoadSceneStartDelay()
        {
            SceneManager.LoadScene(Score._LevelCurrent, LoadSceneMode.Single);
        }

        private void LoadSceneMenu()
        {
            PauseMenu.GameIsPaused = false;
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }*/

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        /*public void UnloadPauseScene(string sceneName)
        {
            Time.timeScale = 1f;
            PauseMenu.GameIsPaused = false;
            SceneManager.UnloadSceneAsync(sceneName);
        }*/

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void LoadOptionsScene(string optionSceneName)
        {
            if (!IsSceneOptionsLoaded)
            {
                SceneManager.LoadScene(optionSceneName, LoadSceneMode.Additive);
                IsSceneOptionsLoaded = true;
            }
        }

        public void UnloadOptionsScene(string optionSceneName)
        {
            if (IsSceneOptionsLoaded)
            {
                SceneManager.UnloadSceneAsync(optionSceneName);
                IsSceneOptionsLoaded = false;
            }
        }

        public void ExitGame()
        {
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        public void TryAgain()
        {
            Scene currentScene = SceneManager.GetActiveScene();

            string sceneName = currentScene.name;

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }



        #region Scene Load and Unload Events Handler
        private void OnEnable()
        {
            SceneManager.sceneUnloaded += SceneUnloadEventHandler;
            SceneManager.sceneLoaded += SceneLoadedEventHandler;
        }

        private void OnDisable()
        {
            SceneManager.sceneUnloaded -= SceneUnloadEventHandler;
            SceneManager.sceneLoaded -= SceneLoadedEventHandler;
        }

        private void SceneUnloadEventHandler(Scene scene)
        {

        }
        private void SceneLoadedEventHandler(Scene scene, LoadSceneMode mode)
        {
            //If the loaded scene is not the SceneOptions, set flag IsOptionsLoaded to
            //false
            if (scene.name.CompareTo("Options") != 0)
            {
                IsSceneOptionsLoaded = false;
            }
        }
    }
    #endregion
}