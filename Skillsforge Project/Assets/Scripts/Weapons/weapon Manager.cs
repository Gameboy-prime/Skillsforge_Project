using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class weaponManager : MonoBehaviour
{
    

    [Header("Bullet Parameter")]
    [SerializeField] float reloadTime, timeBetweenShooting,timeBetweenShots,range, spread;

    [Space]

    [Header("Bullet Forces")]
    [SerializeField] float shootForece;
    [SerializeField] float upwardForce;
    [SerializeField] int bulletLeft, bulletPerTap, bulletShot,damage=10;

    [Header("Booleans")]
    [SerializeField] bool allowButtonHold;

    [Header("External References")]
    [SerializeField] Transform attackPoint;

    [SerializeField] LayerMask shootables;

    private RaycastHit hit;
    

    private bool isReloading, shooting;

    private float elapsedTime;
    public WeaponHandler weaponHandler;

    

    // Start is called before the first frame update
    void Start()
    {
        
        

        shooting = true;
        elapsedTime = timeBetweenShooting;


    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime-= Time.deltaTime;

        if (elapsedTime<0)
        {
            
            Shoot();
            elapsedTime = timeBetweenShooting;
        }
            

        
    }

    void Shoot()
    {
        Debug.Log("The Shoot Function has been called");
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, range, shootables))
        {
            if (hit.point != null)
            {
                Vector3 targetPoint = hit.point;
                Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

                float x = Random.Range(0, spread);

                Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, 0, 0);

                //Instantiate the bullet game object

                GameObject bulletObject = weaponHandler.bulletPool.Get();
                bulletObject.transform.position = attackPoint.position;
                bulletObject.transform.forward = directionWithSpread.normalized;
                bulletObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
                bulletObject.GetComponent<Bullet>().damage = damage;
                

                //Add the forces to the bullet
                bulletObject.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForece, ForceMode.Impulse);
                bulletObject.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * upwardForce, ForceMode.Impulse);


                
                bulletLeft--;
                if (bulletShot < bulletPerTap)
                {
                    Invoke(nameof(Shoot), timeBetweenShots);
                }


            }

        }
        
    }

    

    
}
