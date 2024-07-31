using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReleaseBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Bullet"))
        {
            Debug.Log("THe buullet object has entered the trigger");
            Bullet bullet= other.GetComponent<Bullet>();
            if (bullet.bulletType == BulletType.TypeA)
            {
                Debug.Log("THe bullet type that was released is the type A");
                WeaponHandler.Instance.GetBulletPool(0).Release(other.gameObject);
            }
            else if (bullet.bulletType == BulletType.TypeB)
            {
                WeaponHandler.Instance.GetBulletPool(1).Release(other.gameObject);
            }
            else if (bullet.bulletType == BulletType.TypeC)
            {
                WeaponHandler.Instance.GetBulletPool(2).Release(other.gameObject);
            }
            else if (bullet.bulletType == BulletType.TypeD)
            {
                WeaponHandler.Instance.GetBulletPool(3).Release(other.gameObject);
            }
        }*/
    }
}
