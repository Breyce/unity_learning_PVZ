using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    //public bool isOnGround = false;
    private Transform firePoint;

    private float timer;
    private float internel = 3f;

    //private int currentHealth;
    //private int maxHealth = 10;

    // Start is called before the first frame update
    public override void Start()
    {
        currentHealth = maxHealth;
        firePoint = transform.Find("FirePoint");
        timer = 0;
        isOnGround = false;
    }

    // Update is called once per frame
    private void Update()
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
        //GameObject tmp = Resources.Load<GameObject>("Prefabs/PeaBullet");
        //GameObject go = GameObject.Instantiate(tmp, firePoint);
        GameObject go = BulletPool.Instance.GetPoolObject();
        go.transform.position = firePoint.position;
    }

    ////¸Ä±äÑªÁ¿
    //public int ChangeHealth(int damage)
    //{
    //    currentHealth += damage;
    //    if (currentHealth <= 0)
    //    {
    //        GameObject.Destroy(gameObject);
    //    }
    //    Debug.Log("+++++++++++++++");
    //    Debug.Log(currentHealth);
    //    Debug.Log("+++++++++++++++");

    //    return currentHealth;
    //}
}
