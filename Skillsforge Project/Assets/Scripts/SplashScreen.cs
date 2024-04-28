using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private GameObject MDC;
    [SerializeField] private GameObject skillsForge;
    [SerializeField] private float duration = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SplashLoad());
        
    }

   

    IEnumerator SplashLoad()
    {
        MDC.SetActive(true);
        yield return new WaitForSeconds(duration);
        skillsForge.SetActive(true);
        MDC.SetActive(false);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
