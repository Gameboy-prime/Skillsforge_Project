using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoulderDamageControl : MonoBehaviour
{
    public int health;
    [SerializeField] TextMeshPro text;
    public int currentHealth;

    public GameObject sphere;

    [SerializeField] ParticleSystem effect;
   
    private void Start()
    {
        
        currentHealth = health;
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        text.text= currentHealth.ToString();

        if (currentHealth <= 0)
        {
            Destroy();
        }

    }

    private void Update()
    {
        text.text = currentHealth.ToString();
    }

    private void Destroy()
    {
        GetComponent<SphereCollider>().enabled = false;
       
        StartCoroutine(ReleaseEffect());
        
    }


   

    

    IEnumerator ReleaseEffect()
    {
        
        effect.Play();
        sphere.SetActive(false);
        yield return new WaitForSeconds(1.4f);
        effect.Stop();
        

        FindObjectOfType<PowerupSpawner>().pool.Release(this.gameObject);

    }
}

