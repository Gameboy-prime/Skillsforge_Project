using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public float levelDifficulty;
    public LoadingBar loadingBar;
    public Sounds sound;
    public GameObject UnlockableBox;

    // Start is called before the first frame update
    void Start()
    {
        float value = PlayerPrefs.GetFloat($"dificulty{Difficulty.difficulty+1}");
        if (value == levelDifficulty)
        {
            UnlockableBox.SetActive(false);

        }

        else
        {
            UnlockableBox.SetActive(true);
        }

        
    }


    public void LevelLoad()
    {
        sound.PlayClickSound();
        Difficulty.difficulty = levelDifficulty;
        loadingBar.LoadLevel();
    }
}
