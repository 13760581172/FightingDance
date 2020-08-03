using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    /// <summary>
    /// 负责方向箭头部分的事件
    /// </summary>

    #region 字段变量
    public ArrowType arrowType;
    Image image;
    #endregion

    #region 方法
    //设置箭头的方向与图片
    public void Setup(Sprite sprite, int type)
    {
        image = transform.GetComponent<Image>();
        image.sprite = sprite;          //将图片设置为当前箭头的图片
        arrowType = (ArrowType)type;    //设置方向
    }

    //修改箭头的颜色
    public void ChangeColor(Color color)
    {
        image.color = color;
    }
    #endregion
}

//箭头方向的枚举类型
public enum ArrowType
{
    Up, Down, Left, Right
}
