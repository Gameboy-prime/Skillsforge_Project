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
    void Awake()
    {
        float value = PlayerPrefs.GetFloat("difficulty",0);
        if (levelDifficulty<=value)
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
