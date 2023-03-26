using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameDev4.Dawn
{
    [CreateAssetMenu(menuName = "GameDev4/SoundSettingsPreset", fileName = "SoundSettingsPreset")]

    public class SoundSettings : ScriptableObject
    {
        public AudioMixer AudioMixer;


        [Header("MasterVolume")]
        public string MasterVolumeName = "MasterVolume";
        [Range(-80, 20)]
        public float MasterVolume;

        [Header("BGMVolume")]
        public string BGMVolumeName = "BGMVolume";
        [Range(-80, 20)]
        public float BGMVolume;

        [Header("SFXVolume")]
        public string SFXVolumeName = "SFXVolume";
        [Range(-80, 20)]
        public float SFXVolume;

        [Header("UIVolume")]
        public string UIVolumeName = "UIVolume";
        [Range(-80, 20)]
        public float UIVolume;
    }
}