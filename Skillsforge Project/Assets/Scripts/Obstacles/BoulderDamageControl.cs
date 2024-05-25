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

    private PowerUp powerUp;


   
    private void Start()
    {
        
        currentHealth = health;
        powerUp= GetComponent<PowerUp>();
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        text.text= currentHealth.ToString();

        if (currentHealth <= 0)
        {
            if (powerUp.type == PowerUp.PowerUpType.Gun1)
            {
                WeaponHandler.gunNo = 1;
            }
            else if (powerUp.type == PowerUp.PowerUpType.Gun2)
            {
                WeaponHandler.gunNo = 2;
            }
            else if(powerUp.type == PowerUp.PowerUpType.Gun3)
            {
                WeaponHandler.gunNo = 3;
            }

            else if(powerUp.type == PowerUp.PowerUpType.Gun4)
            {
                WeaponHandler.gunNo = 4;
            }

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
        yield return new WaitForSeconds(1f);
        //effect.Stop();
        

        FindObjectOfType<PowerupSpawner>().pool.Release(this.gameObject);

    }
}

