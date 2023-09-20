using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    private Transform firePoint;

    private float timer;
    private float internel = 3f;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
}
