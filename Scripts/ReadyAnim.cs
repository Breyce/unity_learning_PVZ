using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyAnim : MonoBehaviour
{
    private Animator anim;

    //Ĭ��ʧ��
    private void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        //�����������
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
