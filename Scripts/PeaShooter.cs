using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public bool isOnGround=false;
    private Transform firePoint;

    private float timer;
    private float internel = 3f;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
        Debug.Log(firePoint);
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
        
        //go.transform.position = firePoint.position;
    }
}
