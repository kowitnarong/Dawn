using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace GameDev4.Dawn
{
    public class AudioManager : MonoBehaviour
    {

        public Sound[] sounds;
        public Sound Level1;
        public Sound Level2;
        public Sound Level3;
        public Sound Menu;

        public static AudioManager instance;

        bool PlaySoundLevel1;
        bool PlaySoundLevel2;
        bool PlaySoundLevel3;
        bool PlaySoundMenu;

        public static bool ChangeScene;

        void Start()
        {
            string sceneName = SceneName.SceneNameString;

            /*Level1 = Array.Find(sounds, sound => sound.name == "BG_Scene1");
            Level2 = Array.Find(sounds, sound => sound.name == "BG_Scene2");
            Level3 = Array.Find(sounds, sound => sound.name == "BG_Scene3");*/
            //Menu = Array.Find(sounds, sound => sound.name == "Menu_Scene");

            if (sceneName == "Level1")
            {
                PlaySoundLevel1 = true;
                PlaySoundLevel2 = false;
                PlaySoundLevel3 = false;
                PlaySoundMenu = false;
            }
            else if (sceneName == "Level2")
            {
                PlaySoundLevel1 = false;
                PlaySoundLevel2 = true;
                PlaySoundLevel3 = false;
                PlaySoundMenu = false;
            }
            else if (sceneName == "Level3")
            {
                PlaySoundLevel1 = false;
                PlaySoundLevel2 = false;
                PlaySoundLevel3 = true;
                PlaySoundMenu = false;
            }
            else if (sceneName == "MenuScene")
            {
                PlaySoundLevel1 = false;
                PlaySoundLevel2 = false;
                PlaySoundLevel3 = false;
                PlaySoundMenu = true;
            }

            PlaySoundLevel();
        }
        void Awake()
        {

            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.outputAudioMixerGroup = s.mixerGroup;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.spatialBlend = s.spatial;

            }

            Level1.source = gameObject.AddComponent<AudioSource>();
            Level1.source.clip = Level1.clip;
            Level1.source.outputAudioMixerGroup = Level1.mixerGroup;
            Level1.source.volume = Level1.volume;
            Level1.source.pitch = Level1.pitch;
            Level1.source.loop = Level1.loop;
            Level1.source.spatialBlend = Level1.spatial;

            Level2.source = gameObject.AddComponent<AudioSource>();
            Level2.source.clip = Level2.clip;
            Level2.source.outputAudioMixerGroup = Level2.mixerGroup;
            Level2.source.volume = Level2.volume;
            Level2.source.pitch = Level2.pitch;
            Level2.source.loop = Level2.loop;
            Level2.source.spatialBlend = Level2.spatial;

            Level3.source = gameObject.AddComponent<AudioSource>();
            Level3.source.clip = Level3.clip;
            Level3.source.outputAudioMixerGroup = Level3.mixerGroup;
            Level3.source.volume = Level3.volume;
            Level3.source.pitch = Level3.pitch;
            Level3.source.loop = Level3.loop;
            Level3.source.spatialBlend = Level3.spatial;

            Menu.source = gameObject.AddComponent<AudioSource>();
            Menu.source.clip = Menu.clip;
            Menu.source.outputAudioMixerGroup = Menu.mixerGroup;
            Menu.source.volume = Menu.volume;
            Menu.source.pitch = Menu.pitch;
            Menu.source.loop = Menu.loop;
            Menu.source.spatialBlend = Menu.spatial;
        }

        void Update()
        {
            string sceneName = SceneName.SceneNameString;

            /*if (PauseMenu.GameIsPaused)
            {
                foreach (Sound s in sounds)
                {
                    //Debug.Log(s.source.outputAudioMixerGroup.name);
                    if (s.source.outputAudioMixerGroup.name != "UI")
                    {
                        s.source.Pause();
                    }
                }
            }
            else
            {
                foreach (Sound s in sounds)
                {
                    if (s.source.outputAudioMixerGroup.name != "UI")
                    {
                        s.source.UnPause();
                    }  
                }
            }*/

            if (ChangeScene)
            {
                if (sceneName == "Level1")
                {
                    PlaySoundLevel1 = true;
                    PlaySoundLevel2 = false;
                    PlaySoundLevel3 = false;
                }
                else if (sceneName == "Level2")
                {
                    PlaySoundLevel1 = false;
                    PlaySoundLevel2 = true;
                    PlaySoundLevel3 = false;
                }
                else if (sceneName == "Level3")
                {
                    PlaySoundLevel1 = false;
                    PlaySoundLevel2 = false;
                    PlaySoundLevel3 = true;
                }
                else if (sceneName == "MenuScene")
                {
                    PlaySoundLevel1 = false;
                    PlaySoundLevel2 = false;
                    PlaySoundLevel3 = false;
                    PlaySoundMenu = true;
                }
                StopSoundLevel();
                ChangeScene = false;
            }
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }
            s.source.Play();
        }

        public void PlaySoundLevel()
        {
            if (PlaySoundLevel1)
            {
                if (Level1.source.isPlaying == false)
                {
                    Level1.source.Play();
                }
            }
            else if (PlaySoundLevel2)
            {
                if (Level2.source.isPlaying == false)
                {
                    Level2.source.Play();
                }
            }
            else if (PlaySoundLevel3)
            {
                if (Level3.source.isPlaying == false)
                {
                    Level3.source.Play();
                }
            }
            else if (PlaySoundMenu)
            {
                if (Menu.source.isPlaying == false)
                {
                    Menu.source.Play();
                }
            }
        }

        public void StopSoundLevel()
        {
            if (PlaySoundLevel1)
            {
                if (Level1.source.isPlaying == false)
                {
                    Level1.source.Play();
                }
                Level2.source.Stop();
                Level3.source.Stop();
                Menu.source.Stop();
            }
            else if (PlaySoundLevel2)
            {
                Level1.source.Stop();
                if (Level2.source.isPlaying == false)
                {
                    Level2.source.Play();
                }
                Level3.source.Stop();
                Menu.source.Stop();
            }
            else if (PlaySoundLevel3)
            {
                Level1.source.Stop();
                Level2.source.Stop();
                if (Level3.source.isPlaying == false)
                {
                    Level3.source.Play();
                }
                Menu.source.Stop();
            }
            else if (PlaySoundMenu)
            {
                Level1.source.Stop();
                Level2.source.Stop();
                Level3.source.Stop();
                if (Menu.source.isPlaying == false)
                {
                    Menu.source.Play();
                }
            }
        }
    }
}