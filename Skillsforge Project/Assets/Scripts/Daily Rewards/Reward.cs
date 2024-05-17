using DailyRewardSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{

    [SerializeField] int rewardCoins;

    [Space]
    [Header("Timing")]
    [SerializeField] double rewardDelaySec = 20;
    [SerializeField] float checkForRewardDelay = 5;

   
    [SerializeField] Button claimButton;

    private int nextRewardIndex;
    private bool isRewardReady = false;


    public DailyRewards dailyReward;

    public int rewardDay;
    private void Start()
    {

        if (String.IsNullOrEmpty(PlayerPrefs.GetString($"StartRewardDateTime{rewardCoins}")))
        {
            DateTime dateTimeNow = DateTime.Now;
            PlayerPrefs.SetString($"StartRewardDateTime{rewardCoins}", dateTimeNow.ToString());
        }

        claimButton.onClick.RemoveAllListeners();
        claimButton.onClick.AddListener(Claim);

        int checkIfDayHasPassed = PlayerPrefs.GetInt($"Day{rewardDay}", 0);

        if(checkForRewardDelay != 1)
        {
            StartCoroutine(CheckForRewards());

        }
        
       
    }

    IEnumerator CheckForRewards()
    {
        while (true)
        {
            if (!isRewardReady)
            {
                DateTime dateTimeNow = DateTime.Now;
                DateTime rewardDateTime = DateTime.Parse(PlayerPrefs.GetString("Reward_Next_DateTime", dateTimeNow.ToString()));

                double elapsedSecs = (dateTimeNow - rewardDateTime).TotalSeconds;
                if (elapsedSecs > rewardDelaySec)
                {
                    ActivateReward();
                }
                else
                {
                    DeactivateReward();
                }
            }
            yield return new WaitForSeconds(checkForRewardDelay);
        }
    }

    void ActivateReward()
    {
        isRewardReady=true;
        dailyReward.rewardNotification.SetActive(true);
    }

    void DeactivateReward()
    {
        isRewardReady=false;
        dailyReward.rewardNotification.SetActive(false);
    }
    // Start is called before the first frame update


    

    void Claim()
    {
        dailyReward.ClaimReward(rewardCoins);
        isRewardReady = false;
        dailyReward.rewardNotification.SetActive(false);
        

        PlayerPrefs.SetInt($"Day{rewardDay}", 1);

    }

}
