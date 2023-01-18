using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    [CreateAssetMenu(fileName = "PlayerAbilityPreset", menuName = "GameDev4/PlayerAbillty", order = 0)]
    public class PlayerAbilityPreset : ScriptableObject
    {
        [Header("Texture")]
        public Material material;
        public Mesh mesh;
    }
}

