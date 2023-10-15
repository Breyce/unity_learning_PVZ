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

    private OverPannel overPannel;

    void Start()
    {
        Instance = this;
        sunNum = GameObject.Find("SunNum").GetComponent<Text>();
        chooseBg = GameObject.Find("ChooseBG").gameObject;

        ready = GameObject.Find("ReadyAnim").gameObject.GetComponent<ReadyAnim>();

        overPannel = GameObject.Find("OverPannel").gameObject.GetComponent<OverPannel>();
        
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

    public void GameOver()
    {
        overPannel.Over();
    }
}
