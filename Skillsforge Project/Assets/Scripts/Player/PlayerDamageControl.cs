using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamageControl : MonoBehaviour
{
    [SerializeField] Animator anime;
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
    

    
    
    IEnumerator ReleaseEffect()
    {
        //This portion is for the blood gush effect
        GameObject effect = FindObjectOfType<Effects>().bloodPool.Get();
        effect.transform.position = transform.position;
        effect.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(.3f);
        effects.bloodPool.Release(effect);




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemytag))
        {
            isColliding = true;
            Enemy= other;
        }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(enemytag))
        {
            isColliding = true;
            Enemy = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemytag))
        {
            isColliding = false;
            
        }
    }
    private void Update()
    {

        Debug.Log($"The current DHealt is {currentHealth}");
        
        sec -= Time.deltaTime;
        if(sec < 0)
        {
            Checking();
            sec = damageTime;
        }
    }

    void Checking()
    {
        if (isColliding && !CloneMultiplier.isDead)
        {
            DamageControl control = Enemy.GetComponent<DamageControl>();

            TakeDamage(control.damageLevel);
        }
    }

    private void Start()
    {
        effects= FindObjectOfType<Effects>();
        currentHealth = health;
        
        slider.maxValue = currentHealth;
        slider.value= currentHealth;
        sec = damageTime;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        
        slider.value= currentHealth;
        
        
        if(currentHealth<= 0)
        {
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
