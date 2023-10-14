using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏状态枚举
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

    //初始化
    private void Start()
    {
        currentstate = GameState.Start;
    }

    private void Update()
    {
        StateRefresh();
    }

    //检测状态
    public void StateRefresh()
    {
        switch (currentstate)
        {
            case GameState.Start:
                //隐藏UI 面板  播放开始动画
                UIManager.Instance.HideUI();

                //  摄像机移动到右侧  再移回
                CameraManager.Instance.CameraMove();

                //更改状态
                currentstate = GameState.Fight;
                break;

            case GameState.Fight:
                ZombieManager.Instance.isRefresh = true;

                break;

            case GameState.End:

                break;
        }
    }
}
