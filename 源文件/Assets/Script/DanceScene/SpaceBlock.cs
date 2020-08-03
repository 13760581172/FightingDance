using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBlock : MonoBehaviour
{
    /// <summary>
    /// 负责游戏画面中SpaceBlock的信息
    /// </summary>

    #region 字段变量
    public static SpaceBlock spaceBlock;
    public GameObject pointPrefab;
    #endregion

    #region unity回调函数
    public void Awake()
    {
        spaceBlock = this;
    }
    #endregion

    #region 方法
    //创建光点
    public void CreatePoint()
    {
        Instantiate(pointPrefab, transform);    //实例化光点
    }

    //销毁光点
    public void DestroyPoint()
    {
        Destroy(GameObject.FindWithTag("Point"));       //销毁光点
    }
    #endregion

}
