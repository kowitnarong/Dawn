using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

    [CreateAssetMenu(fileName = "PlayerControllerSettingsPreset", menuName = "GameDev4/PlayerControllerSettingsPreset", order = 0)]
public class PlayerControllerSettingsPreset : ScriptableObject
{

    public float _moveSpeed = 5f;

    [Header("Key Config")]
    public Key _upKey = Key.W;
    public Key _downKey = Key.S;
}
