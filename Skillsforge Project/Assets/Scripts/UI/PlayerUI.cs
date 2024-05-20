using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentGameCoin;

    [SerializeField] private TextMeshProUGUI zombieNum;
    

    // Update is called once per frame
    void Update()
    {
        currentGameCoin.text = GameData.currentGameCoin.ToString();
        zombieNum.text= EnemySpawner.EnemyDeadCount.ToString();
        
    }
}
