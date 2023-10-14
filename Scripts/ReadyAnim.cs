using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyAnim : MonoBehaviour
{
    private Animator anim;

    //默认失活
    private void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //动画播放完毕
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowReady()
    {
        gameObject.SetActive(true);
        anim.Play("ReadyAnim", 0, 0);
    }
}
