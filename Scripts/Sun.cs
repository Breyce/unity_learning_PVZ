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

    //��ʼ��������е����̫���ĳ�ʼ����
    public void InitSkySun(float x, float y, float targetY)
    {

        transform.position = new Vector3(x, y, 0);

        TargetY = targetY;
        
    }
}
