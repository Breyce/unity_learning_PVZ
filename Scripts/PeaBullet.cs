using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 500f;

    private Vector3 dir = new Vector3(1, 0, 0);

    //伤害
    public int damage = 5;

    private IEnumerator DeleteBullet()
    {
        //等待5f    子弹销毁
        yield return new WaitForSeconds(5);
        //GameObject.Destroy(gameObject);
        gameObject.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(DeleteBullet());
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果是僵尸   僵尸减血   子弹失活
        if (collision.tag == "Zombie")
        {
            Zombie zom = collision.GetComponent<Zombie>();
            if (zom != null)
            {
                zom.ChangeHealth(-damage);
                gameObject.SetActive(false);
            }
        }
    }
}
