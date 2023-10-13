using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool isOnGround;
    public int currentHealth;
    public int maxHealth = 10;

    protected Animator anim;

    // Start is called before the first frame update
    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    //¸Ä±äÑªÁ¿
    public virtual int ChangeHealth(int damage)
    {
        currentHealth += damage;
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
