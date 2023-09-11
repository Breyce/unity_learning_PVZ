using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Summary
// ̫����1. �Զ����� 2. ̫��������
public class Sun : MonoBehaviour
{
    //�Ƿ������ϵ���
    private bool isSkySun;

    //���ϵ����̫�������Ŀ���
    private float TargetY;

    private float speed = 100;

    private GameObject sunNum;
    private void Start() 
    {
        sunNum = GameObject.Find("SunNum");
    }

    //��ʼ��������е����̫���ĳ�ʼ����
    public void InitSkySun(float x, float y, float targetY)
    {

        transform.position = new Vector3(x, y, 0);

        TargetY = targetY;
        
        isSkySun = true;
    }

    //ʵ�����������䵽�ݵ���
    private void Update()
    {
        if (isSkySun == true)
        {
            if(transform.position.y > TargetY)
            {
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
            else
            {
                Destroy(gameObject, 3f);
            }
        }

    }

    //ʵ�ֵ�������������������塣
    private void OnMouseDown()
    {
        
        //����ת��

        Vector3 target = Camera.main.ScreenToWorldPoint(sunNum
             .transform.position);
        
        //���÷���
        StartCoroutine(FlyTO(target));
    }

    private IEnumerator FlyTO(Vector3 target)
    {
        //��ȡ��������
        Vector3 dir = (target - transform.position).normalized;
        //�жϾ���
        Debug.Log(dir);
        while (Vector3.Distance(target, transform.position) > 0.1f)
        {
            //�ȴ�0.01 f
            yield return new WaitForSeconds(0.02f);
            transform.Translate(dir * 250f);
        }

        //������С��0.1
        GameObject.Destroy(gameObject);
    }
}
