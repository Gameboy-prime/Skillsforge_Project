using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseBox;
    [SerializeField] private GameObject quitBox;
    public static bool isPaused;
    public Sounds sound;

    // Start is called before the first frame update
   

    public void Pause()
    {
        sound.PlayClickSound();
        StartCoroutine(Pausing());

    }

    IEnumerator Pausing()
    {
        isPaused= true;
        pauseBox.SetActive(true);
        yield return new  WaitForSeconds(.2f);
        Time.timeScale = 0f;

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        sound.PlayClickSound();
        StartCoroutine(Resuming());

    }

    IEnumerator Resuming()
    {
        pauseBox.SetActive(false);
        yield return new WaitForSeconds(.2f);
        
    }

    public void Restart()
    {
        Time.timeScale = 1; ;
        sound.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public  void Menu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        sound.PlayClickSound();
        SceneManager.LoadScene(1);
        
    }

    public void Quit()
    {
        sound.PlayClickSound();
        quitBox.SetActive(true);

    }

    public void Yes()
    {
        sound.PlayClickSound();
        Application.Quit();
    }

    public void No()
    {
        sound.PlayClickSound();
        quitBox.SetActive(false);
    }

    
}
