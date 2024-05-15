using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstTimeInstruction : MonoBehaviour
{
    public GameObject textBox;

    private void Start()
    {
        int num = PlayerPrefs.GetInt("omo2");
        if (num != 2)
        {
            StartCoroutine(Instruct());
            PlayerPrefs.SetInt("omo2", 2);

        }
        
    }

    IEnumerator Instruct()
    {
        textBox.SetActive(true);
        yield return new WaitForSeconds(2f);

        textBox.SetActive(false);
    }
}
