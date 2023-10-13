using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //生成僵尸
    public Transform[] bornPoint;

    public GameObject zombiePrefab;

    private int layerIndex = 0;

    //太阳数
    private int sunCount = 150;

    private void Start()
    {
        Instance = this;
        CreateEnemy();
    }
    //获取阳光
    public int GetSun()
    {
        return sunCount;
    }
    //更新阳光数量及显示
    public void ChangSun(int num)
    {
        if (sunCount + num < 0)
        {
            return;
        }
        //数据

        sunCount += num;

        //UI
        UIManager.Instance.ChangeUICount(sunCount);

    }

    //1.利用路点随机生成
    //等待一定时间 生成
    private IEnumerator CreateZombie(float createTime)
    {
        //等待一定时间
        Debug.Log("等待三秒");
        yield return new WaitForSeconds(createTime);
        Debug.Log("等待完成");
        //生成物体
        GameObject go = GameObject.Instantiate(zombiePrefab);
        //随机坐标
        int index = Random.Range(0, 5);//0 1 2 3 4
        go.transform.parent = bornPoint[index];
        go.transform.localPosition = Vector3.zero;

        ////设置层级
        layerIndex += 1;
        go.GetComponent<SpriteRenderer>().sortingOrder = layerIndex;

        //再生成
        StartCoroutine(CreateZombie(3));
    }

    public void CreateEnemy()
    {
        StartCoroutine(CreateZombie(3));
    }
}
