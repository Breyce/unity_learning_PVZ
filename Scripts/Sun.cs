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

    private float speed = 100;

    private GameObject sunNum;
    private void Start() 
    {
        sunNum = GameObject.Find("SunNum");
    }

    //初始化从天空中掉落的太阳的初始坐标
    public void InitSkySun(float x, float y, float targetY)
    {

        transform.position = new Vector3(x, y, 0);

        TargetY = targetY;
        
        isSkySun = true;
    }

    //实现阳光逐渐下落到草地上
    private void Update()
    {
        if (isSkySun == true)
        {
            if(transform.position.y > TargetY)
            {
                transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
            }
            else
            {
                Destroy(gameObject, 3f);
            }
        }

    }

    //实现点击阳光阳光飞至控制面板。
    private void OnMouseDown()
    {
        
        //坐标转换

        Vector3 target = Camera.main.ScreenToWorldPoint(sunNum
             .transform.position);
        
        //调用方法
        StartCoroutine(FlyTO(target));
    }

    private IEnumerator FlyTO(Vector3 target)
    {
        //获取方向向量
        Vector3 dir = (target - transform.position).normalized;
        //判断距离
        Debug.Log(dir);
        while (Vector3.Distance(target, transform.position) > 0.1f)
        {
            //等待0.01 f
            yield return new WaitForSeconds(0.02f);
            transform.Translate(dir * 250f);
        }

        //当距离小于0.1
        GameObject.Destroy(gameObject);
    }
}
