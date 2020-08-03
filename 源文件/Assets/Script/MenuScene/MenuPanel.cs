using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    /// <summary>
    /// 负责主界面的事件
    /// </summary>
    
    public IntroPanel introPanel;
    public SettingPanel settingPanel;
    public AudioClip music;
   
    public void Start()
    {
        Audio.audioInstance.PlayOnMusic(music);
    }

    //点击开始游戏事件
    public void OnClickStartButton()
    {
        introPanel.ShowPanel();
    }
    //点击设置事件
    public void OnClickSettingButton()
    {
        settingPanel.ShowPanel();
    }
    //退出游戏事件
    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
