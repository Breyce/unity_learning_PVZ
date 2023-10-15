using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //�ٶ�
    private float speed = 25f;
    //����
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

    //��ͷ
    public bool isDie;
    public GameObject head;
    public bool lostHead;

    //��Ϸ����
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
                        //��Ϸ����  Todo
                        LevelManager.Instance.currentstate = GameState.End;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) { return; }

        //���������������ֲ��   
        if (collision.tag == "Plant")
        {
            //���빥��״̬
            isWalk = false;
            anim.SetBool("isWalk", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDie) { return; }
        damageTime += Time.deltaTime;
        //���Թ���
        if (damageTime >= attackInterval)
        {
            //����Time
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

    //�˳�ʱֲ������
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

    //�ı�Ѫ��
    public int ChangeHealth(int damage)
    {
        isHurt = true;
        currentHealth += damage;
        //�жϵ�ǰѪ���Ƿ���Ҫ��ͷ
        if (currentHealth <= lostHeadHealth && !lostHead)
        {
            lostHead = true;
            anim.SetBool("isHurt", true);
            head.SetActive(true);
        }
        if (currentHealth <= 0)
        {
            //������������
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
