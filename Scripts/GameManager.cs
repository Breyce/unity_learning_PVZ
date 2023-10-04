using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //太阳数
    private int sunCount = 150;

    private void Start()
    {
        Instance = this;
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
}
