using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialMultiplier : MonoBehaviour
{
    public TextMeshPro textBox;
    public string multiplierState;
    private string[] operators = { "÷", "-", "+", "*" };

    // Start is called before the first frame update
    void Start()
    {
        CallDeterminatState();



    }

    public void CallDeterminatState()
    {
        
        textBox.text = multiplierState;

    }
}
