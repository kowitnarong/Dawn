using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class CheckCharacterVisibleInScene : MonoBehaviour
    {
        [SerializeField] private PlayerHP playerHP;

        void OnBecameInvisible()
        {
            //Debug.Log("Player is invisible");
            playerHP.TakeDamage(99);
        }
    }
}
