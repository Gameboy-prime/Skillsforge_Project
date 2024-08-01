using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageControl : MonoBehaviour
{
    [SerializeField] Animator anime;
    [SerializeField] GameObject gun;
    [SerializeField] float health;
    [SerializeField] float currentHealth;
    [SerializeField] string enemytag;
    private Effects effects;

    [SerializeField] string dyingAnimeString;

    public Slider slider;

    private float value;

    private bool isColliding;

    private Collider Enemy;

    private  float sec;
    [SerializeField] float damageTime=2;

    public EndGame endGame;


    private bool canDamage=true;
    
    IEnumerator ReleaseEffect()
    {
        //This portion is for the blood gush effect
        GameObject effect = FindObjectOfType<Effects>().bloodPool.Get();
        effect.transform.position = transform.position;
        effect.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(.3f);
        effects.bloodPool.Release(effect);




    }

   

    void OnTriggerStay(Collider other)
    {

        if (!CloneMultiplier.isDead && other.CompareTag(enemytag) && canDamage)
        {
            
            DamageControl control = other.GetComponent<DamageControl>();

            TakeDamage(control.damageLevel);
            canDamage= false;
            Invoke(nameof(CanTakeDamage), 1);
            

        }

    }
    void CanTakeDamage()
    {
        canDamage = true;
    }



    


    private void Start()
    {
        effects= FindObjectOfType<Effects>();
        currentHealth = health;
        
        slider.maxValue = currentHealth;
        slider.value= currentHealth;
        sec = damageTime;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        
        slider.value= currentHealth;
        
        
        if(currentHealth<= 0)
        {
            gun.SetActive(false);
            anime.SetLayerWeight(1, 0);
            anime.Play(dyingAnimeString);
            CloneMultiplier.isDead = true;
            Invoke(nameof(Die), 2);
            
        }
    }

    

    void Die()
    {
        endGame.EndPhase();
    }


}
