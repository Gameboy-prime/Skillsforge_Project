using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDamageControl : MonoBehaviour
{

    [SerializeField] Animator anime;
    [SerializeField] float health;
    [SerializeField] float currentHealth;
    [SerializeField] string enemytag;
    private Effects effects;

    [SerializeField] string dyingAnimeString;

    

    private float value;

    private bool isColliding;

    private Collider Enemy;
    private CloneMove cloneMove;

    private float sec;
    [SerializeField] float damageTime = 2;


    private void Start()
    {
        effects = FindObjectOfType<Effects>();
        cloneMove= GetComponent<CloneMove>();
        currentHealth = health;


        sec = damageTime;
    }



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
            Enemy = other;
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

        //Debug.Log($"The current DHealt is {currentHealth}");

        sec -= Time.deltaTime;
        if (sec < 0)
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

    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        


        if (currentHealth <= 0)
        {
            cloneMove.enabled=false;
            anime.Play(dyingAnimeString);
            

        }
    }



    
}
