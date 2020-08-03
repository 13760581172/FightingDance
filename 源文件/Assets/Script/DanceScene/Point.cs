using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    /// <summary>
    /// 负责光点的移动动画，及到达终点的判定
    /// </summary>

    #region 字段变量
    public static Point point;      //单例模式
    public GameObject pointPrefab;  //光点
    public int x = -480;            //光点x坐标
    public bool isCanSpace;         //能否按下空格键的指标，在EndPoint中即为true
    public bool canGameFinish;      //能否结束游戏的指标
    public Sprite Miss;             //Miss图标
    public Animator Dance;
    #endregion

    #region unity回调函数
    public void Awake()
    {
        point = this;           //单例模式
        Dance = GameObject.Find("Dancer").GetComponent<Animator>();
    }
    public void Update()
    {
        ChangePosition();
    }
    #endregion

    #region 方法
    //光点移动动画
    public void ChangePosition()
    {
        if (x <= 480)
        {
            if (x >= 190 && x <= 360)   //在该范围内可点击空格
                isCanSpace = true;
            else
                isCanSpace = false;
            transform.GetComponent<RectTransform>().localPosition = new Vector2(x, 0);  //移动光点
            x += 6;
            canGameFinish = false;
        }
        if (x == 480)   //x到了最后即没有点击空格
        {
            Destroy(gameObject);        //销毁光点
            GamePanel.game.GetComponent<GamePanel>().isCanReCreat = true;     //标记为可以重新创建
            if (!GamePanel.game.GetComponent<GamePanel>().onlyCreatePoint)
            {
                PlayerPrefs.SetInt("Level", 4);     //因为失败，所以等级从头开始
                Dance.GetComponent<Animator>().SetTrigger("Miss");  //播放Miss动画
                GameObject.Find("Grade").GetComponent<Image>().sprite = Miss;   //设置图片为Miss
                GamePanel.game.GetComponent<GamePanel>().onlyCreatePoint = true;
            }
            else
            {
                GamePanel.game.GetComponent<GamePanel>().onlyCreatePoint = false;
            }
            canGameFinish = true;
        }
    }
    #endregion
}
