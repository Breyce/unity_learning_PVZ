using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private float coolTime = 4;

    private float timer;

    private Image image;

    private GameObject bg;

    //当前的物体
    public GameObject curObj;

    //要创建的植物物体
    public GameObject plantPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        image = transform.Find("Progress").GetComponent<Image>();
        bg = transform.Find("BG").gameObject;
        LoadByName(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateProgress();
        UpdateBg();
    }

    private void UpdateProgress()
    {
        //计算相应的百分比
        float per = Mathf.Clamp(timer / coolTime, 0, 1);

        image.fillAmount = 1 - per;
    }

    private void UpdateBg()
    {
        //1.是否冷却  fillAmount=0
        //2.如果当前拥有的阳光  比消耗的阳光多  

        if (image.fillAmount == 0 )//&& GameMgr.Instance.GetSun() >= costSun)
        {
            bg.SetActive(false);
        }
        else
        {
            bg.SetActive(true);
        }
    }

    //根据名字 加载 物体
    public void LoadByName(string name)
    {
        // 切割字符串
        string[] cardName = name.Split("_");
        //加载预制体
        string resPath = "Prefabs/" + cardName[1];

        plantPrefab = Resources.Load<GameObject>(resPath);
    }

    //屏幕坐标  转  z为0的世界坐标
    public Vector3 ScreenToWorld(Vector3 pos)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(pos);

        //确保pos 为0；
        Vector3 final = new Vector3(position.x, position.y, 0);
        return final;
    }

    //生成一个物体  出现在鼠标所对应的世界处坐标
    public void OnBeginDrag(PointerEventData eventData)
    {
        //  Debug.Log(eventData.position);  
        //  eventData.position  不是  世界坐标    做转换
        //  unity 坐标系   1. 世界坐标系   2.屏幕坐标系     3.视口坐标  

        //如果黑色背景激活: -416,-224
        //if (bg.activeSelf)
        //{
        //    return;
       // }
        curObj = Instantiate(plantPrefab);
        curObj.transform.position = ScreenToWorld(eventData.position);
    }

    //  让物体 跟随 着鼠标
    public void OnDrag(PointerEventData eventData)
    {
    }
    //让物体生成在点击到的格子上
    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
