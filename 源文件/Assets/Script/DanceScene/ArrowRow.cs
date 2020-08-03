using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRow : MonoBehaviour
{
    /// <summary>
    /// 负责GamePanel中箭头栏部分的事件
    /// </summary>

    #region 字段变量
    public static ArrowRow row;
    public Sprite[] arrowSprites;   //箭头图片
    public Color successColor;      //成功的颜色
    public Color errorColor;        //出错的颜色

    public GameObject arrowPrefab;
    Queue<Arrow> arrows = new Queue<Arrow>();   //设置队列，类型为Arrow
    private Arrow currentArrow;      //储存最前的箭头
    public bool isCanFinish;        //箭头是否全部完成指标
    #endregion

    #region unity回调函数
    private void Awake()
    {
        row = this;
    }
    #endregion

    #region 方法
    //创建箭头
    public void CreateArrows(int length)
    {
        for (int i = 0; i < length; i++)
        {
            Arrow arrow = Instantiate(arrowPrefab, transform).GetComponent<Arrow>();    //实例化箭头并获得Arrow组件
            int random = Random.Range(0, 4);    //随机取得0,1,2,3中的一个随机数
            arrow.Setup(arrowSprites[random], random);

            arrows.Enqueue(arrow);      //加入队列
        }
        currentArrow = arrows.Dequeue();    //移除队列的开头对象并返回给currentArrow
    }

    //销毁箭头
    public void DestroyArrows()
    {
        //找到当前场景的所有箭头
        GameObject[] gameObj = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject obj in gameObj)
        {
            Destroy(obj);
        }
        arrows.Clear();     //清除队列
    }

    //判断输入的方向键与箭头是否一致
    public void TypeJudge(KeyCode keyCode)
    {
        //输入正确时
        if (ChangeKeycodeToInt(keyCode) == (int)currentArrow.arrowType)
        {
            currentArrow.ChangeColor(successColor);     //输入正确则改变颜色为绿色
            if (arrows.Count > 0)       //判断队列里是否还有元素，即Count是否大于0
            {
                currentArrow = arrows.Dequeue();    //移除队列的开头对象并返回给currentArrow
            }
            else
                isCanFinish = true;     //队列里没有元素，则标记isCanFinish为true
        }
        else
        {
            //输入错误时
            DestroyArrows();
            int level = PlayerPrefs.GetInt("Level", 4);
            CreateArrows(level);
        }
    }

    //将输入的方向键转换为数字
    public int ChangeKeycodeToInt(KeyCode key)
    {
        int result = 0;
        switch (key)
        {
            case KeyCode.UpArrow:
                {
                    result = 0;
                    break;
                }
            case KeyCode.DownArrow:
                {
                    result = 1;
                    break;
                }
            case KeyCode.LeftArrow:
                {
                    result = 2;
                    break;
                }
            case KeyCode.RightArrow:
                {
                    result = 3;
                    break;
                }
        }
        return result;
    }
    #endregion
}
