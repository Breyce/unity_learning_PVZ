using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    //
    private float timer;
    private float internel = 3.0f;

    private Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();
        timer = 0;
    }

    private void CreateSun()
    {

        //�ж������������ı�
        bool isLeft;
        // Random.Range(0,2) ����0 1
        isLeft = Random.Range(0, 2) < 1;
        GameObject go = Resources.Load<GameObject>("Prefabs/Sun_1");

        if (isLeft)
        {
            float X = Random.Range(transform.position.x - 45f, transform.position.x -36f);
            float Y = Random.Range(transform.position.y - 23f, transform.position.x + 23f);
            GameObject sun = Instantiate(go);
            sun.transform.position = new Vector3(X, Y, 0);

        }
        else
        {
            float X = Random.Range(transform.position.x + 36f, transform.position.x + 45f);
            float Y = Random.Range(transform.position.y - 23f, transform.position.x + 23f);
            GameObject sun = Instantiate(go);
            sun.transform.position = new Vector3(X, Y, 0);
        }
    } 

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > internel)
        {
            //���Ŷ���
            anim.SetBool("isLight", true);
        }
    }

    public void FinishSunAnimOver()
    {
        //��������
        CreateSun();
        Debug.Log("�ɹ���������");
        //����timer  ���ű䰵����
        anim.SetBool("isLight", false);

        timer = 0;
    }

}
