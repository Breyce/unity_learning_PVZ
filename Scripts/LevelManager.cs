using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��Ϸ״̬ö��
public enum GameState
{
    Start,
    Fight,
    End,
}

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;


    public GameState currentstate;

    private void Awake()
    {
        Instance = this;
    }

    //��ʼ��
    private void Start()
    {
        currentstate = GameState.Start;
    }

    private void Update()
    {
        StateRefresh();
    }

    //���״̬
    public void StateRefresh()
    {
        switch (currentstate)
        {
            case GameState.Start:
                //����UI ���  ���ſ�ʼ����
                UIManager.Instance.HideUI();

                //������ƶ����Ҳ�  ���ƻ�
                CameraManager.Instance.CameraMove();

                //����״̬
                currentstate = GameState.Fight;
                break;

            case GameState.Fight:
                ZombieManager.Instance.isRefresh = true;
                break;

            case GameState.End:
                GameOver();
                break;
        }
    }

    public void GameOver()
    {
        //UI  ��ʾ
        UIManager.Instance.GameOver();
        //���̫��ֹͣ����
        SkyManager.Instance.StopCreate();
        //��ʬ ֹͣ����
        ZombieManager.Instance.StopCreateZombie();
        ZombieManager.Instance.ClearZombie();

        StopAllCoroutines();
    }
}
