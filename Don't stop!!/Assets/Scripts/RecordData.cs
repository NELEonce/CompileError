using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordData : MonoBehaviour
{
    public static readonly int StageMaxNum = 3;

    // メンバ変数宣言
    private int stageNum;
    private float clearTime; //ｸﾘｱﾀｲﾑ
    private float[] bestTime = new float[StageMaxNum];  //ﾍﾞｽﾄﾀｲﾑ

    public void SetTime(int num, float clear)
    {
        stageNum = num;
        clearTime = clear;
        if (clearTime < bestTime[num] || bestTime[num] == -1)
        {
            bestTime[num] = clearTime;
        }
    }

    // 起動時に１回だけ呼び出されるメソッド
    private void Start()
    {
        // シーン切り替え時に破棄されない
        DontDestroyOnLoad(gameObject);

        // 初期化処理
        clearTime = -1;
        for (int i = 0; i < StageMaxNum; i++)
        {
            bestTime[i] = -1;
        }
    }

    public void DrawTime(ref float b, ref float c)
    {
        b = bestTime[stageNum];
        c = clearTime;
    }

    public void DrawTime(int num, ref float b, ref float c)
    {
        b = bestTime[num];
        c = clearTime;
    }
}