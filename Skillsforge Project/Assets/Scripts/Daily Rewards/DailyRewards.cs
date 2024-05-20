using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace DailyRewardSystem
{

    public enum RewardType {
        FLASH, 
        COINS
    }

    [Serializable] public struct Reward
    {
        public RewardType Type;
        public int Amount;
    }


    public class DailyRewards : MonoBehaviour
    {
        [Header("Main Menu")]
        [SerializeField] private TextMeshProUGUI coin;

        [Space]

        [Header("Reward UI")]
        [SerializeField] private GameObject rewardBox;
        [SerializeField] private Button openRewardButton;
        [SerializeField] private Button closeRewardButton;

       
       
         public GameObject rewardNotification;
       


        [Space]
        [Header("Timing")]
        [SerializeField] double rewardDelaySec = 20;
        [SerializeField] float checkForRewardDelay = 5;

 
       
       
        private void Start()
        {
            Initialize();
            
        }

        void Initialize()
        {
            
            UpdateCoin();

            openRewardButton.onClick.RemoveAllListeners();
            openRewardButton.onClick.AddListener(OpenRewardInit);

            closeRewardButton.onClick.RemoveAllListeners();
            closeRewardButton.onClick.AddListener(CloseRewardInit);

            

            

        }

        

        

       

        void OpenRewardInit()
        {
            rewardBox.SetActive(true);

        }

        void CloseRewardInit()
        {
            rewardBox.SetActive(false);

        }

        void UpdateCoin()
        {
            coin.text= GameData.Coins.ToString();

        }


        public void ClaimReward(int rewardsCoin)
        {
            GameData.coins += rewardsCoin;
        }

    }

}