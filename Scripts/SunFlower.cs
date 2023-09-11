using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    //
    private float timer;
    private float internel = 3.0f;

    private Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();
        timer = 0;
    }

    private void CreateSun()
    {

        //判断阳光生成在哪边
        bool isLeft;
        // Random.Range(0,2) 返回0 1
        isLeft = Random.Range(0, 2) < 1;
        GameObject go = Resources.Load<GameObject>("Prefabs/Sun_1");

        if (isLeft)
        {
            float X = Random.Range(transform.position.x - 45f, transform.position.x -36f);
            float Y = Random.Range(transform.position.y - 23f, transform.position.x + 23f);
            GameObject sun = Instantiate(go);
            sun.transform.position = new Vector3(X, Y, 0);

        }
        else
        {
            float X = Random.Range(transform.position.x + 36f, transform.position.x + 45f);
            float Y = Random.Range(transform.position.y - 23f, transform.position.x + 23f);
            GameObject sun = Instantiate(go);
            sun.transform.position = new Vector3(X, Y, 0);
        }
    } 

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > internel)
        {
            //播放动画
            anim.SetBool("isLight", true);
        }
    }

    public void FinishSunAnimOver()
    {
        //创建阳光
        CreateSun();
        Debug.Log("成功生成阳光");
        //重置timer  播放变暗动画
        anim.SetBool("isLight", false);

        timer = 0;
    }

}
