using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverPannel : MonoBehaviour
{
    private Image overImage;
    //��ʼʱʧ��
    private void Start()
    {
        overImage = transform.GetComponent<Image>();

        gameObject.SetActive(false);
    }


    public void Over()
    {
        gameObject.SetActive(true);
        StartCoroutine(ReturnStart());
    }

    //�ȴ�0.5f �ص�����0
    private IEnumerator ReturnStart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
