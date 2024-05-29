using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Statistics : MonoBehaviour
{
    [SerializeField] GameObject statBox;
    [SerializeField] GameObject menuBox;

    [Header("Statistics Box")]
    [SerializeField] GameObject coinBox;
    [SerializeField] GameObject zombieBox;
    [SerializeField] GameObject bonusBox;
    [SerializeField] GameObject totalBox;


    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] TextMeshProUGUI zombieText;
    [SerializeField] TextMeshProUGUI bonusText;
    [SerializeField] TextMeshProUGUI totalText;


    private int coinValue;
    private int zombieValue;
    private int totalValue;
    private int bonusValue;
    

    IEnumerator Stats()
    {
        statBox.SetActive(true);
        coinValue = GameData.currentGameCoin;
        zombieValue = EnemySpawner.EnemyDeadCount;
        bonusValue = (int) Difficulty.difficulty* 100;
        totalValue = coinValue + bonusValue;

        yield return new WaitForSeconds(1);
        coinBox.SetActive(true);
        coinText.text= coinValue.ToString();

        yield return new WaitForSeconds(1);
        zombieBox.SetActive(true);
        zombieText.text= zombieValue.ToString();

        yield return new WaitForSeconds(1);
        bonusBox.SetActive(true);
        bonusText.text = bonusValue.ToString();

        yield return new WaitForSeconds(1);
        totalBox.SetActive(true);
        totalText.text= totalValue.ToString();
        menuBox.SetActive(true);


        int coin = PlayerPrefs.GetInt("Coins");
        int currentCoin = totalValue;
        coin += currentCoin;
        PlayerPrefs.SetInt("Coins", coin);
        PlayerPrefs.Save();
        yield return new WaitForSeconds(1);

        Time.timeScale = 0;

       
    }

    public void ShowStats()
    {
        Debug.Log("The Show statistic Function has been called");
        StartCoroutine(Stats());
    }
}
