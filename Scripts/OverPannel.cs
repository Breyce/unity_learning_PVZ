using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverPannel : MonoBehaviour
{
    private Image overImage;
    //开始时失活
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

    //等待0.5f 回到场景0
    private IEnumerator ReturnStart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
