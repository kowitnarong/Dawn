using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev4.Dawn
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] protected SoundSettings m_SoundSettings;

        [Header("Toggle")]
        public Toggle m_ToggleMasterMute;
        public Toggle m_ToggleBGMMute;
        public Toggle m_ToggleSFXMute;
        [Header("Slider")]
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
            //m_SliderMasterVolume.value = m_SoundSettings.MasterVolume;
        }

        public void SetBGMVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.BGMVolumeName, vol);
            m_SoundSettings.BGMVolume = vol;
            m_SliderBGMVolume.value = m_SoundSettings.BGMVolume;
            CheckVolumeMasterMute();
        }

        public void SetSFXVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.SFXVolumeName, vol);
            m_SoundSettings.SFXVolume = vol;
            m_SliderSFXVolume.value = m_SoundSettings.SFXVolume;
            CheckVolumeMasterMute();
        }
        public void SetUIVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.UIVolumeName, vol);
            m_SoundSettings.UIVolume = vol;
            m_SliderUIVolume.value = m_SoundSettings.UIVolume;
        }

        public void ToggleMasterMute()
        {
            if (m_ToggleMasterMute.isOn)
            {
                SetMasterVolume(0);
                m_SliderBGMVolume.interactable = true;
                m_SliderSFXVolume.interactable = true;
                CheckVolumeBGMMute();
                CheckVolumeSFXMute();
            }
            else
            {
                SetMasterVolume(-80);
                m_ToggleBGMMute.isOn = false;
                m_ToggleSFXMute.isOn = false;
                m_SliderBGMVolume.interactable = false;
                m_SliderSFXVolume.interactable = false;
            }
        }

        public void ToggleBGMMute()
        {
            if (m_ToggleBGMMute.isOn)
            {
                m_SliderBGMVolume.interactable = true;
                m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.BGMVolumeName, m_SliderBGMVolume.value);
                m_SoundSettings.BGMVolume = m_SliderBGMVolume.value;
                m_SliderBGMVolume.value = m_SoundSettings.BGMVolume;
            }
            else
            {
                SetBGMVolume(-80);
                m_SliderBGMVolume.interactable = false;
            }
        }

        public void ToggleSFXMute()
        {
            if (m_ToggleSFXMute.isOn)
            {
                m_SliderSFXVolume.interactable = true;
                m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.SFXVolumeName, m_SliderSFXVolume.value);
                m_SoundSettings.SFXVolume = m_SliderSFXVolume.value;
                m_SliderSFXVolume.value = m_SoundSettings.SFXVolume;
            }
            else
            {
                SetSFXVolume(-80);
                m_SliderSFXVolume.interactable = false;
            }
        }

        public void CheckVolumeMasterMute()
        {
            if (m_SoundSettings.BGMVolume == -80 && m_SoundSettings.SFXVolume == -80)
            {
                m_ToggleMasterMute.isOn = false;
            }
            else
            {
                m_ToggleMasterMute.isOn = true;
            }
        }

        public void CheckVolumeBGMMute()
        {
            m_ToggleBGMMute.isOn = true;
            ToggleBGMMute();
        }

        public void CheckVolumeSFXMute()
        {
            m_ToggleSFXMute.isOn = true;
            ToggleSFXMute();
        }
    }
}