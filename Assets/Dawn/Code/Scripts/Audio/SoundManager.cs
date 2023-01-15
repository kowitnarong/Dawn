using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] protected SoundSettings m_SoundSettings;

        public Slider m_SliderMasterVolume;
        public Slider m_SliderBGMVolume;
        public Slider m_SliderSFXVolume;
        public Slider m_SliderUIVolume;

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
            m_SliderMasterVolume.value = m_SoundSettings.MasterVolume;
        }

        public void SetBGMVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.BGMVolumeName, vol);
            m_SoundSettings.BGMVolume = vol;
            m_SliderBGMVolume.value = m_SoundSettings.BGMVolume;
        }

        public void SetSFXVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.SFXVolumeName, vol);
            m_SoundSettings.SFXVolume = vol;
            m_SliderSFXVolume.value = m_SoundSettings.SFXVolume;
        }
        public void SetUIVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.UIVolumeName, vol);
            m_SoundSettings.UIVolume = vol;
            m_SliderUIVolume.value = m_SoundSettings.UIVolume;
        }
    }
}