using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// 负责游戏部分音乐与音效的控制
    /// </summary>

    #region 字段变量
    public static AudioManager audioManager;
    public AudioSource BgMusic, Space, Arrow, Winner;
    #endregion

    #region unity回调函数

    void Awake()
    {
        audioManager = this;        //单例模式
        //获取音乐的AudioSource组件
        BgMusic = transform.Find("BgMusic").GetComponent<AudioSource>();
        Space = transform.Find("Space").GetComponent<AudioSource>();
        Arrow = transform.Find("Arrow").GetComponent<AudioSource>();
        Winner = transform.Find("Winner").GetComponent<AudioSource>();

        //获取到保存的声音大小
        BgMusic.volume = PlayerPrefs.GetFloat("musicValue", 1.0f);
        Space.volume = PlayerPrefs.GetFloat("soundValue", 1.0f);
        Arrow.volume = PlayerPrefs.GetFloat("soundValue", 1.0f);
        Winner.volume = PlayerPrefs.GetFloat("soundValue", 1.0f);
    }
    #endregion

    #region 方法
    //播放空格键音效
    public void PlayOnSpace(AudioClip space)
    {
        Space.PlayOneShot(space);    //按空格时的音效
    }

    //播放方向键音效
    public void PlayOnArrow(AudioClip arrow)
    {
        Arrow.PlayOneShot(arrow);    //按方向键时的音效
    }

    //播放背景音乐
    public void PlayOnMusic(AudioClip bgMusic)
    {
        BgMusic.clip = bgMusic;   //获取Clip
        BgMusic.loop = false;        //设置循环播放为false
        BgMusic.Play();			//播放音乐
    }

    //播放胜利音效
    public void PlayOnWinner(AudioClip winner)
    {
        Winner.clip = winner;   //获取Clip
        Winner.loop = true;        //设置循环播放为true
        Winner.Play();			//播放音乐
    }
    #endregion

}
