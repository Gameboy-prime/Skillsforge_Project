using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    public TextMeshPro textBox;
    public string multiplierState;
    private string[] operators= { "�", "-","+" };

    // Start is called before the first frame update
    void Start()
    {
        CallDeterminatState();
        
        
        
    }

    public void CallDeterminatState()
    {
       // Debug.Log("CallDetermineState Function was called");
        string op = operators[Random.Range(0, 3)];

        if(CloneMultiplier.playerNum>3 && op == "*")
        {
            op = "+";
        }

        if (CloneMultiplier.playerNum > 5)
        {
            int rad = Random.Range(0, 2);
            if (rad == 0)
            {
                op= "�";
            }
            else if (rad == 1)
            {
                op = "-";
            }
            
        }
        string value = Random.Range(1, 3).ToString();
        multiplierState = op + " " + value;
        textBox.text = multiplierState;

    }

    
}
