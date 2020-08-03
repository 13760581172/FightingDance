using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroPanel : MonoBehaviour
{
    /// <summary>
    /// 负责介绍界面的事件
    /// </summary>

    //显示界面
    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    //开始演出事件
    public void OnClickStartGameButton()
    {
        SceneManager.LoadScene(1);
    }
}
