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

    //花费的阳光
    public int costSun;

    //当前的物体
    public GameObject curObj;

    //要创建的植物物体
    public GameObject plantPrefab;

    // Start is called before the first frame update
    void Start()
    {
        costSun = 50;
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
        //1.是否冷却 fillAmount=0
        //2.如果当前拥有的阳光比消耗的阳光多  

        if (image.fillAmount == 0 && GameManager.Instance.GetSun() >= costSun)
        {
            bg.SetActive(false);
        }
        else
        {
            bg.SetActive(true);
        }
    }

    //根据名字加载物体
    public void LoadByName(string name)
    {
        // 切割字符串
        string[] cardName = name.Split("_");
        //加载预制体
        string resPath = "Prefabs/" + cardName[1];

        plantPrefab = Resources.Load<GameObject>(resPath);
    }

    //屏幕坐标转z为0的世界坐标
    public Vector3 ScreenToWorld(Vector3 pos)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(pos);

        //确保pos 为0；
        Vector3 final = new Vector3(position.x, position.y, 0);
        return final;
    }

    //生成一个物体出现在鼠标所对应的世界处坐标
    public void OnBeginDrag(PointerEventData eventData)
    {
        //  Debug.Log(eventData.position);  
        //  eventData.position  不是世界坐标  做转换
        //  unity 坐标系   1. 世界坐标系   2.屏幕坐标系     3.视口坐标  

        //如果黑色背景激活: -416,-224
        if (bg.activeSelf){ return; }
        curObj = Instantiate(plantPrefab);
        curObj.transform.position = ScreenToWorld(eventData.position);
    }

    //  让物体 跟随 着鼠标
    public void OnDrag(PointerEventData eventData)
    {
        if (curObj != null)
        {
            curObj.transform.position = ScreenToWorld(eventData.position);
        };
    }
    //让物体生成在点击到的格子上
    public void OnEndDrag(PointerEventData eventData)
    {
        //计时器重置
        timer = 0;

        //UI更新  
        GameManager.Instance.ChangSun(-costSun);
        UIManager.Instance.ChangeUICount(GameManager.Instance.GetSun());

        //开始正式种植
        if (curObj == null) { return; }
        Collider2D[] col = Physics2D.OverlapPointAll(ScreenToWorld(eventData.position));

        // 遍历所有的格子
        for (int i = 0; i < col.Length; i++)
        {

            //考虑条件：1 是格子；2 有没有植物
            if (col[i].tag == "Land" && col[i].gameObject.transform.childCount == 0)
            {
                curObj.transform.position = col[i].transform.position;

                curObj.transform.SetParent(col[i].transform);


                //这里我们生成的是游戏物体  拖动时会调用方法
                //会出现 拖动时发射子弹的bug
                //设置isOnGround 为true


                //以豌豆为例 后续会提取Plant 类
                //PeaShooter obj = curObj.GetComponent<PeaShooter>();

                //if (obj != null)
                //{

                //    obj.isOnGround = true;

                //}

                Plant obj = curObj.GetComponent<Plant>();

                if (obj != null)
                {

                    obj.isOnGround = true;

                }

                curObj = null;
                return;
            }

        }

        // 如果没有合适的格子   curob还在
        if (curObj != null)
        {
            GameObject.Destroy(curObj);
            curObj = null;
        }
    }
}
