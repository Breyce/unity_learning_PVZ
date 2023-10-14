using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private void Awake()
    {
        Instance = this;
        // ��ʼ������
        transform.position = new Vector3(-164, 0, -3324);
    }

    public void CameraMove()
    {
        StartCoroutine(MoveRight());
    }

    //�����ƶ�
    private IEnumerator MoveRight()
    {
        //����ƶ����ұ�ʱ  ����������ʾ�Ľ�ʬ
        ZombieManager.Instance.CreateStartZombie();
        //�� x<1 ��  ÿ��0.02   �����ƶ�0.04
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
        //�� x>=-3 ��  ÿ��0.02   �����ƶ�0.04
        while (transform.position.x >= -163)
        {
            yield return new WaitForSeconds(0.02f);
            transform.position -= new Vector3(3.3f, 0, 0);
        }

        // ����  ��ʾ�Ľ�ʬ
        ZombieManager.Instance.DestoryZombieShow();
        //��ʾUI
        UIManager.Instance.ShowUI();
        UIManager.Instance.ChangeUICount(GameManager.Instance.GetSun());

        //��ʾ׼������
        UIManager.Instance.ShowReady();

        //���⿪ʼ����
        SkyManager.Instance.StartCreateSun();
    }
}
