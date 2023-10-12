using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    private float speed = 500f;

    private Vector3 dir = new Vector3(1, 0, 0);

    //�˺�
    public int damage = 5;

    private IEnumerator DeleteBullet()
    {
        //�ȴ�5f    �ӵ�����
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
        // ����ǽ�ʬ   ��ʬ��Ѫ   �ӵ�ʧ��
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
