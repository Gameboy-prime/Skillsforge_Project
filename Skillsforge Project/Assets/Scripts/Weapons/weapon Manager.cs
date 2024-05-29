using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static Bullet;

public class weaponManager : MonoBehaviour
{
    [Header("Bullet Parameter")]
    [SerializeField] float reloadTime, timeBetweenShooting, timeBetweenShots, range, spread;

    [Header("Bullet Forces")]
    [SerializeField] float shootForce;
    [SerializeField] float upwardForce;
    [SerializeField] int bulletLeft, bulletPerTap, damage = 10;

    [Header("Booleans")]
    [SerializeField] bool allowButtonHold;

    [Header("External References")]
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask shootables;

    private RaycastHit hit;
    private bool isReloading, shooting;
    private float elapsedTime;
    

    void Start()
    {
        shooting = true;
        elapsedTime = timeBetweenShooting;
        WeaponHandler.gunNo = 0; // Set this to the appropriate gun number for this weapon
    }

    void Update()
    {
        elapsedTime -= Time.deltaTime;

        if (elapsedTime < 0 && !isReloading && bulletLeft > 0)
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



        GameObject bulletObject = WeaponHandler.Instance.GetBulletPool(WeaponHandler.gunNo).Get();

        bulletObject.transform.position = attackPoint.position;
        bulletObject.transform.forward = directionWithSpread.normalized;
        bulletObject.transform.rotation = Quaternion.Euler(-90, 0, 0);

        Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        bulletRigidbody.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);

        ReturnBullet(5f, bulletObject);

        bulletLeft--;

        // Return the bullet to the pool after a delay (for demonstration purposes, use actual logic in your game)
       
    }

    IEnumerator ReturnBullet(float waitTime, GameObject objBullet)
    {
        yield return new WaitForSeconds(waitTime);

        if(objBullet.activeInHierarchy)
        {
            Bullet bullet = objBullet.GetComponent<Bullet>();
            if (bullet.bulletType == BulletType.TypeA)
            {
                Debug.Log("THe bullet type that was released is the type A");
                WeaponHandler.bulletPools[0].Release(objBullet);
            }
            else if (bullet.bulletType == BulletType.TypeB)
            {
                WeaponHandler.bulletPools[1].Release(objBullet);
            }
            else if (bullet.bulletType == BulletType.TypeC)
            {
                WeaponHandler.bulletPools[2].Release(objBullet);
            }
            else if (bullet.bulletType == BulletType.TypeD)
            {
                WeaponHandler.bulletPools[3].Release(objBullet);
            }
        }

       


    }

    

    
    
}
