using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text scorText;
    public Text BestScoreText;
    public GameObject gameoverPanel;

    //Đưa dữ liệu vào score
    public void SetScoreText(string txt)
    {
        if (scorText)
        {
            scorText.text = txt;
        }
    }

    // Đưa dữ liệu vào điểm số cao nhất
    public void SetBestScoreText(string txt)
    {
        if (BestScoreText)
        {
            BestScoreText.text = txt;
        }
    }

    //Hiển thị gameoverpanel 
    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.SetActive(isShow);
        }
    }
}
