using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : Plant
{
    private Transform firePoint;

    private float timer;
    private float internel = 3f;

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
        GameObject go = BulletPool.Instance.GetPoolObject();
        go.transform.position = firePoint.position;
    }
}
