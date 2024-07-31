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
    private CarActivator car;



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
            powerUp = GetComponent<PowerUp>();

            if (powerUp.type == PowerUp.PowerUpType.Gun1)
            {
                WeaponHandler.gunNo = 0;
            }
            else if (powerUp.type == PowerUp.PowerUpType.Gun2)
            {
                WeaponHandler.gunNo = 1;
            }
            else if (powerUp.type == PowerUp.PowerUpType.Gun3)
            {
                WeaponHandler.gunNo = 2;
            }

            else if (powerUp.type == PowerUp.PowerUpType.Gun4)
            {
                WeaponHandler.gunNo = 3;
            }
            if (powerUp.canActivateTank)
            {
                car = FindObjectOfType<CarActivator>();
                car.ActivateCar();
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

