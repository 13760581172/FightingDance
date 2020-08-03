using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    /// <summary>
    /// 负责游戏时输入方向键与空格键的判定
    /// </summary>

    #region 字段变量
    private int reCreatLevel;
    private int score;
    public Sprite Miss;
    public Sprite Great;
    public Sprite Perfect;
    public AudioClip space;
    public AudioClip arrow;
    public Animator Dance;
    #endregion

    #region unity回调函数
    void Update()
    {
        //如果onlyCreatePoint指标为false时
        if (!GameObject.Find("GamePanel").GetComponent<GamePanel>().onlyCreatePoint)
        {
            //上箭头
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                JudgeArrow(KeyCode.UpArrow);
            }

            //下箭头
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                JudgeArrow(KeyCode.DownArrow);
            }

            //左箭头
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                JudgeArrow(KeyCode.LeftArrow);
            }

            //右箭头
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                JudgeArrow(KeyCode.RightArrow);
            }

            //空格键
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.audioManager.PlayOnSpace(space);    //播放音效
                if (ArrowRow.row.isCanFinish && Point.point.isCanSpace) //isCanFinish和isCanSpace皆为true时执行
                {
                    //按下空格键后，可重新创建并只创建光点
                    GamePanel.game.GetComponent<GamePanel>().isCanReCreat = true;
                    GamePanel.game.GetComponent<GamePanel>().onlyCreatePoint = true;

                    //获得分数与等级
                    score = PlayerPrefs.GetInt("Score", 0);
                    reCreatLevel = PlayerPrefs.GetInt("Level", 4);

                    //将分数加上当前等级作为分数储存
                    PlayerPrefs.SetInt("Score", score + reCreatLevel);

                    //达到第4，5，6等级时
                    if (reCreatLevel == 4 || reCreatLevel == 5 || reCreatLevel == 6)
                    {
                        GameObject.Find("Grade").GetComponent<Image>().sprite = Great;
                    }
                    //达到第7等级时
                    else if (reCreatLevel == 7)
                    {
                        //设置图片为great，需循环次数为2
                        JudgeLevel(Great, 2);
                    }
                    //达到第8、9等级时
                    else if (reCreatLevel == 8 || reCreatLevel == 9)
                    {
                        //设置图片为great，需循环次数为4
                        JudgeLevel(Great, 4);
                    }
                    //达到第10等级时,只要不失误就一直保持第10等级
                    else if (reCreatLevel == 10)
                    {
                        //设置图片为Perfect
                        GameObject.Find("Grade").GetComponent<Image>().sprite = Perfect;
                        //等级减1即不可升级
                        reCreatLevel -= 1;
                    }

                    //等级加1后保存（不可升级时会将level先减1）
                    PlayerPrefs.SetInt("Level", reCreatLevel + 1);
                    //isCanFinish和isCanSpace皆设为false
                    ArrowRow.row.isCanFinish = false;
                    Point.point.isCanSpace = false;
                }
                else
                {
                    //不可按空格键时按空格的事件
                    Dance.GetComponent<Animator>().SetTrigger("Miss");  //播放Miss动画（暂无合适动画）
                    GameObject.Find("Grade").GetComponent<Image>().sprite = Miss;   //设置图片为Miss
                    GamePanel.game.GetComponent<GamePanel>().isCanReCreat = true;
                    GamePanel.game.GetComponent<GamePanel>().onlyCreatePoint = true;
                    //失误时重置等级为4
                    PlayerPrefs.SetInt("Level", 4);
                    PlayerPrefs.SetInt("Count", 0);
                    ArrowRow.row.isCanFinish = false;
                    Point.point.isCanSpace = false;
                }
            }
        }
    }
    #endregion

    #region 方法
    public void JudgeArrow(KeyCode keyCode)
    {
        //播放按下方向键音效，判断按下方向键和最前面的方向箭头是否一致
        AudioManager.audioManager.PlayOnArrow(arrow);
        ArrowRow.row.TypeJudge(keyCode);
    }

    public void JudgeLevel(Sprite sprite,int countNumber)
    {
        //设置等级图片
        GameObject.Find("Grade").GetComponent<Image>().sprite = sprite;
        //完成两次后可升级
        int count = PlayerPrefs.GetInt("Count", 0);
        if (count < countNumber)
        {
            //等级减1即不可升级
            reCreatLevel -= 1;
            count += 1;
            PlayerPrefs.SetInt("Count", count);
        }
        else
            PlayerPrefs.SetInt("Count", 0);
    }
    #endregion
}
