using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseBlock : MonoBehaviour
{
    public WallSpawner spawner;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Release(other));
        
    }

    IEnumerator Release(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            yield return new WaitForSeconds(.2f);
            spawner.DespawnBlock(other.gameObject);

        }
    }
}
