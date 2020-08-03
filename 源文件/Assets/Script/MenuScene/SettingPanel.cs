using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    /// <summary>
    /// 负责设置界面的事件
    /// </summary>

    #region 字段变量
    public Slider musicSlider;
    public Slider soundSlider;
    #endregion

    #region 方法
    //显示界面
    public void ShowPanel()
    {
        gameObject.SetActive(true);
        musicSlider.value = PlayerPrefs.GetFloat("musicValue", 1);
        soundSlider.value = PlayerPrefs.GetFloat("soundValue", 1);
    }
    //隐藏界面
    public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    //修改游戏背景音乐音量大小
    public void OnChangeMusicSlider(float musicValue)
    {
        PlayerPrefs.SetFloat("musicValue", musicValue);
        Audio.audioInstance.OnMusicVolumeChange(musicValue);
    }

    //修改音效音量大小
    public void OnChangeSoundSlider(float soundValue)
    {
        PlayerPrefs.SetFloat("soundValue", soundValue);
    }
    #endregion
}
