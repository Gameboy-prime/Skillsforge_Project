using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject[] gunObjects;
    public enum PowerUpType { 
        Gun1, Gun2, Gun3,Gun4
    }

    public PowerUpType type;

    public void Activate()
    {
        int rad= Random.Range(0, gunObjects.Length);
        if (rad == 0)
        {
            type = PowerUpType.Gun1;

        }
        else if (rad == 1)
        {
            type = PowerUpType.Gun2;
        }

        else if (rad == 2)
        {
            type = PowerUpType.Gun3;
        }
        else if(rad == 3)
        {
            type = PowerUpType.Gun4;
        }

        ChooseGun(rad);
    }

    void ChooseGun(int gunNo)
    {
        for (int i =0; i< gunObjects.Length; i++)
        {
            gunObjects[i].gameObject.SetActive(false);
        }

        gunObjects[gunNo].gameObject.SetActive(true);

        //Debug.Log("The power up is " + gunNo);
    }

    

}
