using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //速度
    private float speed = 25f;
    //方向
    private Vector3 dir = new Vector3(-1, 0, 0);
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }
}
