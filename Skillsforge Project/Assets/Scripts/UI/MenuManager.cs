using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseBox;
    [SerializeField] private GameObject quitBox;
    public static bool isPaused;
   

    // Start is called before the first frame update
   

    public void Pause()
    {
        
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
       
        StartCoroutine(Resuming());

    }

    IEnumerator Resuming()
    {
        pauseBox.SetActive(false);
        yield return new WaitForSeconds(.2f);
        
    }

    public void Restart()
    {
        
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public  void Menu()
    {
        isPaused = false;
        
        
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;

    }

    public void Quit()
    {
        
        quitBox.SetActive(true);

    }

    public void QuitGame()
    {
        
        Application.Quit();
    }

    public void No()
    {
        
        quitBox.SetActive(false);
        pauseBox.SetActive(true);
    }

    public void TutorialLevel()
    {
        

        SceneManager.LoadScene(3);
    }





}
