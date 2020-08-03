using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    /// <summary>
    /// 负责界面部分音乐的控制
    /// </summary>

    #region 字段变量
    public static Audio audioInstance;
    public AudioSource bgMusic;
    #endregion

    #region unity回调函数
    private void Awake()
    {
        audioInstance = this;
        //获取两个音乐的AudioSource组件
        bgMusic = transform.Find("bgMusic").GetComponent<AudioSource>();

        //获取到保存的声音大小
        bgMusic.volume = PlayerPrefs.GetFloat("musicValue", 1.0f);
    }
    #endregion

    #region 方法
    //播放背景音乐
    public void PlayOnMusic(AudioClip music)
    {
        bgMusic.clip = music;       //获取Clip
        bgMusic.loop = true;        //设置循环播放为true
        bgMusic.Play();			  //播放音乐
    }
    //修改主界面背景音乐音量
    public void OnMusicVolumeChange(float value)
    {
        bgMusic.volume = value;
    }
    #endregion

}
