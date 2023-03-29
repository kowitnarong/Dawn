using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameDev4.Dawn
{
    public class CoinUI : MonoBehaviour
    {
        [SerializeField] private CoinCount coinCount;
        [SerializeField] private int coin;
        [SerializeField] private TextMeshProUGUI coinText;

        private void Start()
        {
            coin = coinCount.currentCoin;
            UpdateCoin(coin);
            coinCount.onCoinCountChange += UpdateCoin;
        }

        private void OnDestroy()
        {
            coinCount.onCoinCountChange -= UpdateCoin;
        }

        private void UpdateCoin(int coin)
        {
            this.coin = coin;
            coinText.text = "X " + this.coin.ToString();
        }
    }
}
