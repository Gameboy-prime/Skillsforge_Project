using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;

public class CarWeaponManager : MonoBehaviour
{
    public ObjectPool<GameObject> bulletPool;
    //public GameObject bullet;

    [SerializeField] Transform attackPoint;
    [SerializeField] float spread=30, range,upwardForce, shootForce;
    [SerializeField] int bulletLeft, bulletPerTap=5;

    [SerializeField] float[] directionValue;

    public LayerMask shootables;

    [SerializeField] float elapsedTime, timeBetweenShooting=2;
    private bool isReloading;


    RaycastHit hit;
    // Start is called before the first frame update
    private void Start()
    {
        elapsedTime = timeBetweenShooting;
    }

    private void Update()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime < 0)
        {
            Shoot();
            elapsedTime = timeBetweenShooting;
        }
    }


    void Shoot()
    {
        //Debug.Log("The Shoot Function has been called");


        Vector3 targetPoint;

        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, range, shootables))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = attackPoint.position + attackPoint.forward * range;
        }

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        float spreadX = Random.Range(-spread, spread);
        float spreadY = Random.Range(-spread, spread);
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(spreadX, spreadY, 0);



        int value = 0;

        for(int i=0; i<bulletPerTap; i++)
        {
            GameObject bulletObject = WeaponHandler.Instance.GetBulletPool(4).Get();
            bulletObject.transform.position = attackPoint.position;
            bulletObject.transform.forward = directionWithSpread.normalized;
            
            bulletObject.transform.rotation = Quaternion.Euler(-90, directionValue[value], 0);
            value++;

        }



        //for 

        bulletLeft--;

        // Return the bullet to the pool after a delay (for demonstration purposes, use actual logic in your game)

    }


}
