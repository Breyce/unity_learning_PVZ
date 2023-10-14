using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private void Awake()
    {
        Instance = this;
        // 初始化坐标
        transform.position = new Vector3(-164, 0, -3324);
    }

    public void CameraMove()
    {
        StartCoroutine(MoveRight());
    }

    //向右移动
    private IEnumerator MoveRight()
    {
        //相机移动到右边时  创建用于显示的僵尸
        ZombieManager.Instance.CreateStartZombie();
        //当 x<1 是  每隔0.02   向右移动0.04
        while (transform.position.x <= 164)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position += new Vector3(3.3f, 0, 0);
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(MoveLeft());
    }

    private IEnumerator MoveLeft()
    {
        //当 x>=-3 是  每隔0.02   向左移动0.04
        while (transform.position.x >= -163)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position -= new Vector3(3.3f, 0, 0);
        }

        // 消除  显示的僵尸
        ZombieManager.Instance.DestoryZombieShow();
        //显示UI
        UIManager.Instance.ShowUI();
        UIManager.Instance.ChangeUICount(GameManager.Instance.GetSun());

        //显示准备动画
        UIManager.Instance.ShowReady();

        //阳光开始创建
        SkyManager.Instance.StartCreateSun();
    }
}
