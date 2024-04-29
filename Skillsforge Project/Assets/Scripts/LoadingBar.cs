using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    public int LevelIndex;
    public TextMeshProUGUI loaderText;
    public GameObject loaderBox;
    // Start is called before the first frame update
    
    public void LoadLevel()
    {
        loaderBox.SetActive(true);
        StartCoroutine(Loader(LevelIndex));
    }

    IEnumerator Loader(int index)
    {
        AsyncOperation operation= SceneManager.LoadSceneAsync(index);

        while(!operation.isDone)
        {
            float value = operation.progress;
            slider.value= value / 0.9f;
            loaderText.text= Mathf.Round((value/0.9f)*100).ToString();
            yield return null;



        }


    }
}
