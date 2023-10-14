using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    private GameObject chooseBg;
    private ReadyAnim ready;

    private Text sunNum;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        sunNum = GameObject.Find("SunNum").GetComponent<Text>();
        chooseBg = GameObject.Find("ChooseBG").gameObject;

        ready = GameObject.Find("ReadyAnim").gameObject.GetComponent<ReadyAnim>();
    }

    public void ChangeUICount(int num)
    {
        sunNum.text = num.ToString();
    }

    public void HideUI()
    {
        chooseBg.SetActive(false);
    }

    public void ShowUI()
    {
        chooseBg.SetActive(true);
    }

    public void ShowReady()
    {
        ready.ShowReady();
    }
}
