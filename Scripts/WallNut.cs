using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNut : Plant
{
    public override void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = 20;
    }

    public override int ChangeHealth(int damage)
    {
        currentHealth += damage;

        if(currentHealth <= 10 && currentHealth >=5) 
            anim.SetBool("isCracked1", true);
        else if(currentHealth <= 5) 
            anim.SetBool("isCracked2", true);

        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        Debug.Log("+++++++++++++++");
        Debug.Log(currentHealth);
        Debug.Log("+++++++++++++++");
        return currentHealth;
    }
}
