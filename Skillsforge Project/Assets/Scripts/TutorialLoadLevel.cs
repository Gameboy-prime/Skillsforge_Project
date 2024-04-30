using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLoadLevel : MonoBehaviour
{
    public LoadingBar loadingBar;
    public Sounds sound;
    public void LevelLoad()
    {
        sound.PlayClickSound();
        
        loadingBar.LoadLevel();
    }
}
