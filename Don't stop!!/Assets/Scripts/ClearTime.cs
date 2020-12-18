using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using System.Text.RegularExpressions;


public class ClearTime : MonoBehaviour
{
    // メンバ変数宣言
    public TextMeshProUGUI text_ClearTime; // ステージ クリアタイム
    public TextMeshProUGUI text_BestTime;  // ステージ 最速クリアタイム

    void Start()
    {
        // データスクリプトを取得
        Data data = GameObject.Find("DataManager").GetComponent<Data>();

        // クリアタイムをUIに表示
        float b = 0,c = 0;
        int stageNum = 0;
        if (SceneManager.GetActiveScene().name == "Select")
        {
            stageNum = int.Parse(Regex.Replace(text_BestTime.name, @"[^0-9]", "")) - 1;
            data.DrawTime(stageNum, ref b, ref c);
        }
        else
        {
            data.DrawTime(ref b, ref c);
        }
        if (c == -1) c = 0;
        if (b == -1) b = 0;
        var cMinute = (int)c / 60;
        var cSecond = (int)c % 60;
        var bMinute = (int)b / 60;
        var bSecond = (int)b % 60;
        if (text_ClearTime  != null)
        {
            text_ClearTime.text = string.Format("{0:d2}:{1:d2}:{2:d2}", cMinute, cSecond, (int)(c * 100 % 100));
        }

        if (text_BestTime != null)
        {
            text_BestTime.text = string.Format("{0:d2}:{1:d2}:{2:d2}", bMinute, bSecond, (int)(b * 100 % 100));
        }
    }
}