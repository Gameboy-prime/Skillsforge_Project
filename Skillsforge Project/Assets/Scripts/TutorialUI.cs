using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cloneNum;

    [SerializeField] private TextMeshProUGUI zombieNum;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        cloneNum.text = CloneMultiplier.playerNum.ToString();
        zombieNum.text = CloneMultiplier.ZombieNum.ToString();

    }
}
