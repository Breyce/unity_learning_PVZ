using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance;

    //�洢���б�
    public List<Zombie> zombies = new List<Zombie>();
    public GameObject zombiePrefab;
    public Transform[] bornPoint;
    public List<Zombie> zombieShow = new List<Zombie>();

    //�Ƿ�ˢ��
    public bool isRefresh = false;

    //���ò㼶
    private int layerIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        CreateByTime();
    }

    public void CreateZombie()
    {
        //��������
        GameObject go = GameObject.Instantiate(zombiePrefab);
        //�������
        int index = Random.Range(0, 5);//0 1 2 3 4
        go.transform.parent = bornPoint[index];
        go.transform.localPosition = Vector3.zero;

        ////���ò㼶
        layerIndex += 1;
        go.GetComponent<SpriteRenderer>().sortingOrder = layerIndex;

        AddZombie(go.GetComponent<Zombie>());
    }

    public void AddZombie(Zombie zom)
    {
        zombies.Add(zom);
    }

    public void RemoveZombie(Zombie zom)
    {
        zombies.Remove(zom);
    }

    public void CreateStartZombie()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject go = GameObject.Instantiate(zombiePrefab);
            //�������
            int index = Random.Range(0, 5);//0 1 2 3 4
            go.transform.parent = bornPoint[index];
            go.transform.localPosition = Vector3.zero;

            Zombie zombie = go.GetComponent<Zombie>();
            zombieShow.Add(zombie);
            go.GetComponent<Animator>().speed = 0;

            zombie.isWalk = false;
        }
    }

    public void DestoryZombieShow()
    {

        for (int i = 0; i < zombieShow.Count; i++)
        {
            GameObject.Destroy(zombieShow[i].gameObject);
        }
    }

    public void CreateByTime()
    {
        StartCoroutine(CreateSomeZombie());
    }

    //ʹ�ü�����
    private IEnumerator CreateSomeZombie()
    {
        while (layerIndex < 12)
        {
            //�Ƿ���ˢ
            if (isRefresh == true)
            {
                int delay = Random.Range(2, 5);
                yield return new WaitForSeconds(delay);

                int randomNum = Random.Range(1, 4);
                for (int i = 0; i < randomNum; i++)
                {
                    CreateZombie();
                }
            }
            yield return new WaitForSeconds(5);
        }
        yield return new WaitForSeconds(5);
        StartCoroutine(CreateSomeZombie());
    }

    public void StopCreateZombie()
    {
        StopAllCoroutines();
    }
}
