using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WeaponHandler : MonoBehaviour
{
    [Header("Gun Object")]
    [SerializeField] GameObject bullet;
    [Space]
    public ObjectPool<GameObject> bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(bullet);
        },
        obj =>
        {
            obj.SetActive(true);
            // obj.GetComponentInChildren<TrailRenderer>().enabled = true;
            obj.GetComponent<Rigidbody>().isKinematic = false;

        },
        obj =>
        {
            obj.SetActive(false);
            //obj.GetComponentInChildren<TrailRenderer>().enabled = false;
            obj.GetComponent<Rigidbody>().isKinematic = true;
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 50, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
