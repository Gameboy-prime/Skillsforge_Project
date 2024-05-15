using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] private GameObject instructionBox;
    [SerializeField] private string instructionDisplay;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Instruct(other));
        
    }

    IEnumerator Instruct(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instructionBox.GetComponent<TextMeshProUGUI>().text = instructionDisplay;

            instructionBox.SetActive(true);
            //Time.timeScale = 0f;
            yield return new  WaitForSeconds(2f);
            instructionBox.SetActive(false);

            //Time.timeScale = 1f;



        }

    }

}
