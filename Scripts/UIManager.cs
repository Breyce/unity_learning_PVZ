using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Text sunNum;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        sunNum = GameObject.Find("SunNum").GetComponent<Text>();
    }

    public void ChangeUICount(int num)
    {
        sunNum.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
