using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    //�ӵ�Ԥ����
    public GameObject bulletPrefab;
    //���������
    public int amount = 10;
    // ��Ʒ�б�
    private List<GameObject> pool = new List<GameObject>();


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {   //��������ص�����
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(bulletPrefab);
            //������ʧ��
            go.SetActive(false);
            //��ӵ������
            pool.Add(go);
        }
    }

    //�Ӷ���ػ�ȡ����
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            //�ҳ�δ�����������  ���伤��  ������
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        //���û���������������� �������� ��ӵ����� �������
        GameObject go = GameObject.Instantiate(bulletPrefab);
        pool.Add(go);

        go.SetActive(true);
        return go;
    }
}
