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

    private bool isWalk = true;
    private bool isHurt = false;

    public int damage = 10;
    public float attackInterval = 1f;
    private float damageTime;
    private int currentHealth = 60;
    private int maxHealth = 60;
    private int lostHeadHealth = 40;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalk)
        {
            anim.SetBool("isWalk", true);
            transform.position += dir * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果我们碰到的是植物   
        if (collision.tag == "Plant")
        {
            //进入攻击状态
            isWalk = false;
            anim.SetBool("isWalk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        damageTime += Time.deltaTime;
        //可以攻击
        if (damageTime >= attackInterval)
        {
            //重置Time
            damageTime = 0;
            //扣血 暂时以豌豆射手为例 后面会提Plant类
            PeaShooter plant = collision.gameObject.GetComponent<PeaShooter>();
            if (plant != null)
            {
                plant.ChangeHealth(-damage);
            }
        }
    }

    //退出时植物死亡
    private void OnTriggerExit2D(Collider2D collision)
    {
        PeaShooter plant = collision.gameObject.GetComponent<PeaShooter>();

        if (plant != null)
        {
            if(plant.ChangeHealth(0) <= 0)
            {
                isWalk = true;
                anim.SetBool("isWalk", true);
            }
        }
    }

    //改变血量
    public int ChangeHealth(int damage)
    {
        isHurt = true;
        currentHealth += damage;
        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        Debug.Log("****************");
        Debug.Log(currentHealth);
        Debug.Log("****************");

        return currentHealth;
    }
}
