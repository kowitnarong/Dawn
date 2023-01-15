using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GameDev4.Dawn
{
    [System.Serializable]
    public class Sound
    {
        public string name;

        public AudioClip clip;
        public AudioMixerGroup mixerGroup;

        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;
        [Range(0f, 1f)]
        public float spatial;

        public bool loop;

        [HideInInspector]
        public AudioSource source;
    }
}