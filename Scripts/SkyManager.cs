using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public static SkyManager Instance;

    private float MinX = -400F;
    private float MaxX = 250F;

    private float MinY = -230F;
    private float MaxY = 200F;

    private GameObject sunPre;
    //x=-400 - 250; y=340
    private void Awake()
    {
        Instance = this;

        sunPre = Resources.Load<GameObject>("Prefabs/Sun_1");

        //InvokeRepeating("CreatSun", 2, 5);
    }

    //创建太阳
    public void StartCreateSun(float delay = 5)
    {
        InvokeRepeating("CreateSun", 2, delay);
    }

    //停止创建
    public void StopCreate()
    {
        CancelInvoke();
    }

    public void CreateSun()
    {
        //生成太阳
        GameObject go = GameObject.Instantiate(sunPre);
        Sun sun = go.GetComponent<Sun>();
        //初始化坐标
        float X = Random.Range(MinX, MaxX);
        float Y = Random.Range(MinY, MaxY);

        sun.InitSkySun(X, 325, Y);
    }
}
