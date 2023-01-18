using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class KeepSoundSetting : MonoBehaviour
    {
        public SoundSettings m_SoundSettings;

        void Start()
        {
            InitialiseVolumes();
        }
        private void InitialiseVolumes()
        {
            SetMasterVolume(m_SoundSettings.MasterVolume);
            SetBGMVolume(m_SoundSettings.BGMVolume);
            SetSFXVolume(m_SoundSettings.SFXVolume);
            SetUIVolume(m_SoundSettings.UIVolume);
        }

        public void SetMasterVolume(float vol)
        {
            //Set float to the audiomixer
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.MasterVolumeName, vol);
            //Set float to the scriptable object to persist the value although the game is closed
            m_SoundSettings.MasterVolume = vol;
            //Set the slider bar's value         
        }

        public void SetBGMVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.BGMVolumeName, vol);
            m_SoundSettings.BGMVolume = vol;           
        }

        public void SetSFXVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.SFXVolumeName, vol);
            m_SoundSettings.SFXVolume = vol;
        }
        public void SetUIVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.UIVolumeName, vol);
            m_SoundSettings.UIVolume = vol;
        }
    }
}