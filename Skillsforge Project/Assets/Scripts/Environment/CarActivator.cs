using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarActivator : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] float powerUpCarTime=7;



    public void ActivateCar()
    {

        car.SetActive(true);
        LeanTween.moveLocalZ(car, 3, 3);
        Invoke(nameof(DeativateCar), powerUpCarTime);

    }

    public void DeativateCar()
    {
        StartCoroutine(DeactivatingCar());
    }
    IEnumerator DeactivatingCar()
    {
        LeanTween.moveLocalZ(car, -3, 3);
        yield return new WaitForSeconds(2);
        car.SetActive(false);
    }
}
