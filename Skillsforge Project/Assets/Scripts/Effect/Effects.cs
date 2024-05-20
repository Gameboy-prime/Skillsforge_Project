using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Effects : MonoBehaviour
{
    [SerializeField] GameObject bloodEffect;
    public ObjectPool<GameObject> pool;
    // Start is called before the first frame update
    void Start()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(bloodEffect);
        },

        obj =>
        {
            obj.SetActive(true);
        },

        obj =>
        {
            obj.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 100, 200);

    }

    
}
