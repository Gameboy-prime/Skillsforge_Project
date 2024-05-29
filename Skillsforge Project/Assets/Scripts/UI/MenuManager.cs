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
        
        
        sound.PlayClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public  void Menu()
    {
        isPaused = false;
        
        sound.PlayClickSound();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

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
        pauseBox.SetActive(true);
    }

    public void TutorialLevel()
    {
        sound.PlayClickSound();

        SceneManager.LoadScene(3);
    }



}
