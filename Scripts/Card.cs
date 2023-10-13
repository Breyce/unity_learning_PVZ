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

    //���ѵ�����
    public int costSun;

    //��ǰ������
    public GameObject curObj;

    //Ҫ������ֲ������
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
        //������Ӧ�İٷֱ�
        float per = Mathf.Clamp(timer / coolTime, 0, 1);

        image.fillAmount = 1 - per;
    }

    private void UpdateBg()
    {
        //1.�Ƿ���ȴ fillAmount=0
        //2.�����ǰӵ�е���������ĵ������  

        if (image.fillAmount == 0 && GameManager.Instance.GetSun() >= costSun)
        {
            bg.SetActive(false);
        }
        else
        {
            bg.SetActive(true);
        }
    }

    //�������ּ�������
    public void LoadByName(string name)
    {
        // �и��ַ���
        string[] cardName = name.Split("_");
        //����Ԥ����
        string resPath = "Prefabs/" + cardName[1];

        plantPrefab = Resources.Load<GameObject>(resPath);
    }

    //��Ļ����תzΪ0����������
    public Vector3 ScreenToWorld(Vector3 pos)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(pos);

        //ȷ��pos Ϊ0��
        Vector3 final = new Vector3(position.x, position.y, 0);
        return final;
    }

    //����һ������������������Ӧ�����紦����
    public void OnBeginDrag(PointerEventData eventData)
    {
        //  Debug.Log(eventData.position);  
        //  eventData.position  ������������  ��ת��
        //  unity ����ϵ   1. ��������ϵ   2.��Ļ����ϵ     3.�ӿ�����  

        //�����ɫ��������: -416,-224
        if (bg.activeSelf){ return; }
        curObj = Instantiate(plantPrefab);
        curObj.transform.position = ScreenToWorld(eventData.position);
    }

    //  ������ ���� �����
    public void OnDrag(PointerEventData eventData)
    {
        if (curObj != null)
        {
            curObj.transform.position = ScreenToWorld(eventData.position);
        };
    }
    //�����������ڵ�����ĸ�����
    public void OnEndDrag(PointerEventData eventData)
    {
        //��ʱ������
        timer = 0;

        //UI����  
        GameManager.Instance.ChangSun(-costSun);
        UIManager.Instance.ChangeUICount(GameManager.Instance.GetSun());

        //��ʼ��ʽ��ֲ
        if (curObj == null) { return; }
        Collider2D[] col = Physics2D.OverlapPointAll(ScreenToWorld(eventData.position));

        // �������еĸ���
        for (int i = 0; i < col.Length; i++)
        {

            //����������1 �Ǹ��ӣ�2 ��û��ֲ��
            if (col[i].tag == "Land" && col[i].gameObject.transform.childCount == 0)
            {
                curObj.transform.position = col[i].transform.position;

                curObj.transform.SetParent(col[i].transform);


                //�����������ɵ�����Ϸ����  �϶�ʱ����÷���
                //����� �϶�ʱ�����ӵ���bug
                //����isOnGround Ϊtrue


                //���㶹Ϊ�� ��������ȡPlant ��
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

        // ���û�к��ʵĸ���   curob����
        if (curObj != null)
        {
            GameObject.Destroy(curObj);
            curObj = null;
        }
    }
}
