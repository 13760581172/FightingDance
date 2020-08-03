using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverPanel : MonoBehaviour
{
    /// <summary>
    /// 负责结果界面的信息
    /// </summary>

    #region 字段变量
    public Text finalScore;
    public Image image;
    public int score;
    public Sprite D;
    public Sprite C;
    public Sprite B;
    public Sprite A;
    public Sprite S;
    public Sprite SS;
    public Sprite SSS;
    #endregion

    #region unity回调函数
    private void Awake()
    {
        image = transform.Find("FinalGrade").GetComponent<Image>();
    }
    #endregion

    #region 方法
    //重新开始
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(1);
    }
    //返回界面
    public void OnClickExitButton()
    {
        SceneManager.LoadScene(0);
    }
    //展示界面
    public void ShowPanel()
    {
        gameObject.SetActive(true);
        score = PlayerPrefs.GetInt("Score", 0);
        this.finalScore.text = score.ToString();
        //根据分数更换FinalGrade的图片
        if (score < 50)
            image.sprite = D;
        else if (score >= 50 && score < 100)
            image.sprite = C;
        else if (score >= 100 && score < 150)
            image.sprite = B;
        else if (score >= 150 && score < 200)
            image.sprite = A;
        else if (score >= 200 && score < 250)
            image.sprite = S;
        else if (score >= 250 && score < 300)
            image.sprite = SS;
        else
            image.sprite = SSS;
    }
    #endregion

}
