using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    

    public void HeyEnd()
    {
        Time.timeScale = 0;

    }

    public void SaveProgress()
    {
       
        float num = Difficulty.difficulty;
        float check = PlayerPrefs.GetFloat("difficulty",0);

        if (num >= check)
        {
            PlayerPrefs.SetFloat("difficulty", num + 1);
        }



        PlayerPrefs.Save();
        
    }
}
