using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    //子弹预制体
    public GameObject bulletPrefab;
    //对象池容量
    public int amount = 10;
    // 物品列表
    private List<GameObject> pool = new List<GameObject>();


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {   //创建对象池的物体
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(bulletPrefab);
            //让物体失活
            go.SetActive(false);
            //添加到对象池
            pool.Add(go);
        }
    }

    //从对象池获取物体
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            //找出未被激活的物体  将其激活  并返回
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        //如果没有满足条件的物体 创建物体 添加到池中 激活并返回
        GameObject go = GameObject.Instantiate(bulletPrefab);
        pool.Add(go);

        go.SetActive(true);
        return go;
    }
}
