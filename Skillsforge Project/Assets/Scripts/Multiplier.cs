using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    public TextMeshPro textBox;
    public string multiplierState;
    private string[] operators= { "÷", "-","+", "*" };

    // Start is called before the first frame update
    void Start()
    {
        CallDeterminatState();
        
        
        
    }

    public void CallDeterminatState()
    {
       // Debug.Log("CallDetermineState Function was called");
        string op = operators[Random.Range(0, 4)];

        if(CloneMultiplier.playerNum>40 && op == "*")
        {
            op = "+";
        }
        string value = Random.Range(1, 3).ToString();
        multiplierState = op + " " + value;
        textBox.text = multiplierState;

    }

    
}
