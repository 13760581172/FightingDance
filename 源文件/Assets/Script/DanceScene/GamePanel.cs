using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    /// <summary>
    /// 负责游戏主界面信息和游戏的基本逻辑（输入逻辑请到InputManager）
    /// </summary>

    #region 字段变量

    public static GamePanel game;
    private int level;                   //游戏等级
    public bool isCanReCreat;           //是否可重新创建光点与方向键指标
    public bool onlyCreatePoint;        //是否只创建光点指标
    public AudioClip music;    //背景音乐
    public AudioClip winner;      //胜利音乐
    public Animator Dance;
    public OverPanel overPanel;
    public Text scoreText;
    public Text levelText;
    private int score;                   //得分
    private float time;
    public bool startOverTime;
    private float overTime;
    #endregion

    #region unity回调函数
    private void Awake()
    {
        game = this;
        //赋初值
        PlayerPrefs.SetInt("Level", 4);
        PlayerPrefs.SetInt("Count", 0);
        PlayerPrefs.SetInt("Score", 0);
        startOverTime = false;
        overTime = 0;
    }

    public void Start()
    {
        AudioManager.audioManager.PlayOnMusic(music);    //播放背景音乐
        onlyCreatePoint = true;     //一开始设为只创建光点，供玩家缓冲
        ReCreate();
    }

    private void Update()
    {
        //游戏时间到音乐尾声时
        time += Time.deltaTime;
        
        if (Point.point.canGameFinish)
        {
            if (time > 235)
            {
                {
                    Dance.GetComponent<Animator>().SetTrigger("Win");   //播放win动画（暂无找到适合的动画）
                    AudioManager.audioManager.PlayOnWinner(winner); //播放win音乐
                    Destroy();
                    startOverTime = true;
                }
            }
        }

        //游戏结束后5秒再显示得分界面
        if (startOverTime)
            overTime += Time.deltaTime;
        if (overTime > 5)
            overPanel.ShowPanel();

        //可重新创建判定
        if (isCanReCreat)
        {
            ReCreate();
            isCanReCreat = false;
        }

        //更新界面信息
        level = PlayerPrefs.GetInt("Level", 4);
        this.levelText.text = level.ToString();
        score = PlayerPrefs.GetInt("Score", 0);
        this.scoreText.text = score.ToString();
    }
    #endregion

    #region 方法
    //创建
    public void Game()
    {
        ArrowRow.row.CreateArrows(level);
        SpaceBlock.spaceBlock.CreatePoint();
    }

    //重新创建
    public void ReCreate()
    {
        ArrowRow.row.DestroyArrows();
        SpaceBlock.spaceBlock.DestroyPoint();
        //onlyCreatePoint为true时只创建光点，为false时创建光点和方向键
        if (onlyCreatePoint == true)
            SpaceBlock.spaceBlock.CreatePoint();
        else
        {
            Game();
        }
    }

    //销毁Panel
    public void DestroyPanel()
    {
        Destroy(gameObject);
    }

    //销毁GamePanel下的所有子物体
    private void Destroy()
    {
        List<Transform> list = new List<Transform>();
        foreach (Transform child in transform)
        {
            list.Add(child);
        }
        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i].gameObject);
        }
    }
    #endregion
}
