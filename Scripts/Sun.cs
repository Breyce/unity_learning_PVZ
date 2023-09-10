using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Summary
// 太阳：1. 自动生成 2. 太阳花掉落
public class Sun : MonoBehaviour
{
    //是否是天上掉落
    private bool isSkySun;

    //天上掉落的太阳下落的目标点
    private float TargetY;

    //初始化从天空中掉落的太阳的初始坐标
    public void InitSkySun(float x, float y, float targetY)
    {

        transform.position = new Vector3(x, y, 0);

        TargetY = targetY;
        
    }
}
