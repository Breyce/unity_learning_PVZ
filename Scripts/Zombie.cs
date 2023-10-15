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

    public bool isWalk = true;
    public bool isHurt = false;

    public int damage = 10;
    public float attackInterval = 1f;
    private float damageTime;
    private int currentHealth = 60;
    private int maxHealth = 60;
    private int lostHeadHealth = 40;

    //掉头
    public bool isDie;
    public GameObject head;
    public bool lostHead;

    //游戏结束
    private Vector3 finalPoint;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        head = transform.Find("head").gameObject;
        head.SetActive(false);
        isDie = false;
        lostHead = false;

        finalPoint = new Vector3(-545F, -61.28901F, 0);
    }


    void Update()
    {
        if (LevelManager.Instance.currentstate == GameState.Fight)
        {
            if (isDie) { return; }
            if (isWalk)
            {
                anim.SetBool("isWalk", true);
                transform.position += dir * Time.deltaTime * speed;

                if (transform.position.x < -545f)
                {
                    Vector3 dir = (finalPoint - transform.position).normalized;
                    transform.Translate(dir * Time.deltaTime * speed);

                    if (Vector3.Distance(finalPoint, transform.position) < 50f)
                    {
                        //游戏结束  Todo
                        LevelManager.Instance.currentstate = GameState.End;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) { return; }

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
        if (isDie) { return; }
        damageTime += Time.deltaTime;
        //可以攻击
        if (damageTime >= attackInterval)
        {
            //重置Time
            damageTime = 0;

            Plant plant = collision.gameObject.GetComponent<Plant>();

            if (plant != null)
            {
                plant.ChangeHealth(-damage);
                if (plant.currentHealth <= 0)
                {
                    isWalk = true;
                    anim.SetBool("isWalk", true);
                }
            }
        }
    }

    //退出时植物死亡
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isDie) { return; }

        Plant plant = collision.gameObject.GetComponent<Plant>();

        if (plant != null)
        {
            if (plant.ChangeHealth(0) <= 0)
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
        //判断当前血量是否需要掉头
        if (currentHealth <= lostHeadHealth && !lostHead)
        {
            lostHead = true;
            anim.SetBool("isHurt", true);
            head.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            //播放死亡动画
            anim.SetTrigger("Die");
            isDie = true;
        }
        Debug.Log("****************");
        Debug.Log(currentHealth);
        Debug.Log("****************");

        return currentHealth;
    }

    public void DieAnim()
    {
        anim.enabled = false;

        GameObject.Destroy(gameObject);
    }
}
