using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //̫����
    private int sunCount = 150;

    private void Start()
    {
        Instance = this;
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
}
