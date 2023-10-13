using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //���ɽ�ʬ
    public Transform[] bornPoint;

    public GameObject zombiePrefab;

    private int layerIndex = 0;

    //̫����
    private int sunCount = 150;

    private void Start()
    {
        Instance = this;
        CreateEnemy();
    }
    //��ȡ����
    public int GetSun()
    {
        return sunCount;
    }
    //����������������ʾ
    public void ChangSun(int num)
    {
        if (sunCount + num < 0)
        {
            return;
        }
        //����

        sunCount += num;

        //UI
        UIManager.Instance.ChangeUICount(sunCount);

    }

    //1.����·���������
    //�ȴ�һ��ʱ�� ����
    private IEnumerator CreateZombie(float createTime)
    {
        //�ȴ�һ��ʱ��
        Debug.Log("�ȴ�����");
        yield return new WaitForSeconds(createTime);
        Debug.Log("�ȴ����");
        //��������
        GameObject go = GameObject.Instantiate(zombiePrefab);
        //�������
        int index = Random.Range(0, 5);//0 1 2 3 4
        go.transform.parent = bornPoint[index];
        go.transform.localPosition = Vector3.zero;

        ////���ò㼶
        layerIndex += 1;
        go.GetComponent<SpriteRenderer>().sortingOrder = layerIndex;

        //������
        StartCoroutine(CreateZombie(3));
    }

    public void CreateEnemy()
    {
        StartCoroutine(CreateZombie(3));
    }
}
