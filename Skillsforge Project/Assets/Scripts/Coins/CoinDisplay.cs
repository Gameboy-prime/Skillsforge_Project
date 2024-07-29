using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText;

    private void Start()
    {
        Invoke(nameof(CheckCoins), 1);
    }

    private void CheckCoins()
    {
        coinText.text = GameData.coins.ToString();
    }
}
