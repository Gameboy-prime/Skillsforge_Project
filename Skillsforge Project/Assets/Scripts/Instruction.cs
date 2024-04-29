using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private GameObject instructionBox;
    // Start is called before the first frame update
    void Start()
    {
        int num = PlayerPrefs.GetInt("instruct");
        if (num != 2)
        {
            StartCoroutine(Instruct());
            PlayerPrefs.SetInt("instruct", 2);
            PlayerPrefs.Save();



        }

    }

    

    IEnumerator Instruct()
    {
        instructionBox.SetActive(true);
        yield return new WaitForSeconds(4);
        instructionBox.SetActive(false);

        
    }

}
