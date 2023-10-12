using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public bool isOnGround = false;
    private Transform firePoint;

    private float timer;
    private float internel = 3f;

    private int currentHealth;
    private int maxHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        firePoint = transform.Find("FirePoint");
        timer = 0;
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround == false) return;
        timer += Time.deltaTime;
        if (timer >= internel)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        GameObject tmp = Resources.Load<GameObject>("Prefabs/PeaBullet");
        GameObject go = GameObject.Instantiate(tmp, firePoint);
    }

    //¸Ä±äÑªÁ¿
    public int ChangeHealth(int damage)
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
