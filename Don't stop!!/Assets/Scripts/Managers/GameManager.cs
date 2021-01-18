using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DontStop.Player;



public class GameManager : MonoBehaviour
{
    private Controller1 controller;
    private MouseFollow mouseFollow;

    private GameObject player;

    [SerializeField]
    private　GameObject CanvasObject;            //オプション画面
    
    private GameObject timeText;                //ゲーム中にタイムを表示する

    private　GameObject gameCanvas;             //ゲーム中UI

    [SerializeField]
    private　GameObject ResultCanvas;           //リザルト画面
    
    private GameObject image;                   //ﾌｪｰﾄﾞ用の画像

    public bool playEnd { get; set; }   // ﾒｲﾝｹﾞｰﾑが終了しているかのフラグ
    private float playEndTime;          // ﾒｲﾝｹﾞｰﾑ後の経過時間(秒)
    private float playTime;             // 時間(秒)
    private bool isCalledOnce;          // 一回だけ呼びたい
 

    private void Awake()
    {
        //導蟲取得
        mouseFollow = GameObject.Find("ScoutfliesCanvas").GetComponent<MouseFollow>();

        controller = new Controller1();

        // canvas内の使用する物の取得
        gameCanvas = GameObject.Find("GameCanvas");
        timeText = gameCanvas.transform.Find("TimeText (TMP)").gameObject;

        //Callbackの登録
        controller.Option.Open.started += _ => OpenOpstion();

        //ﾁｭｰﾄﾘｱﾙｼｰﾝなら
        if (SceneManager.GetActiveScene().name == "Practice")
        {
            timeText.SetActive(false);
            image = Instantiate(Resources.Load<GameObject>("UI/Image"));
            image.transform.parent = gameCanvas.transform;
            image.transform.localPosition = Vector3.zero;
        }
    }

    private void OnEnable()
    {
        controller.Enable();
    }

    private void OnDisable()
    {
        controller.Disable();
    }

    private void OnDestroy()
    {
        controller.Dispose();
    }

    private void Start()
    {
        //ｵﾌﾞｼﾞｪｸﾄの非表示
        CanvasObject.SetActive(false);

        //ゲーム中UI
        gameCanvas.SetActive(true);

        //導蟲の非表示
        mouseFollow.mouseFlag = false;

        //禰豆子の取得
        player = GameObject.Find("Nezuko");

        //ｹﾞｰﾑ終了ﾌﾗｸﾞ
        playEnd = false;

        isCalledOnce = false;

        //3秒後に動き出す
        StartCoroutine(moveTime());

        //最初は動かない
        Time.timeScale = 0;
    }

    private void Update()
    {
        // 時間をカウントして表示
        if (!playEnd)
        {
            // ｹﾞｰﾑが終了していなければ経過時間をカウント
            playTime += Time.deltaTime;
            int minute = (int)playTime / 60;
            int second = (int)playTime % 60;
            if (timeText.activeSelf)timeText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:d2}:{1:d2}:{2:d2}", minute, second, (int)(playTime * 100 % 100));
        }
        else if(playEnd)
        {
            //ｹﾞｰﾑが終了したら
            playEndTime = 0.0f;

            //ｻﾞ・ﾜｰﾙﾄﾞ
            Time.timeScale = 0;
            var player = GameObject.Find("Nezuko");
            player.GetComponent<FPCharacterController>().enabled = false;

            //ﾁｭｰﾄﾘｱﾙｼｰﾝなら
            if (SceneManager.GetActiveScene().name == "Practice")
            {
                //ﾌｪｰﾄﾞｱｳﾄ
                image.GetComponent<Image>().color += Color.black * 0.006f;
                if (image.GetComponent<Image>().color.a >= 1)
                //結果は出さずにｾﾚｸﾄ画面に戻る
                GameEventMessage.SendEvent("SelectTrantion");
                return;
            }

            //ﾘｻﾞﾙﾄ画面表示
            if (!isCalledOnce)
            {
                //導蟲の表示
                mouseFollow.mouseFlag = true;

                isCalledOnce = true;
                //ｹﾞｰﾑ中
                gameCanvas.SetActive(false);

                // データスクリプトを取得
                RecordData data = GameObject.Find("DataManager").GetComponent<RecordData>();

                for (int i = 0; i < RecordData.StageMaxNum; i++)
                {
                    //各ｽﾃｰｼﾞによって結果を表示する
                    if (SceneManager.GetActiveScene().name == "Stage" + (1+i).ToString())
                    {
                        data.SetTime(i, playTime);
                    }
                }
                var canvas = ResultCanvas.GetComponent<Canvas>();
                canvas.worldCamera = GameObject.Find("SubCamera").GetComponent<Camera>();
                Instantiate(ResultCanvas);
            }
        }   
    }

    //Escｷｰを押したら
    private void OpenOpstion()
    {
        if (!playEnd)
        {
            //ｻﾞ・ﾜｰﾙﾄﾞ
            Time.timeScale = 0;
            var player = GameObject.Find("Nezuko");
            player.GetComponent<FPCharacterController>().enabled = false;

            //ｵﾌﾞｼﾞｪｸﾄの表示
            CanvasObject.SetActive(true);

            //導蟲の表示
            mouseFollow.mouseFlag = true;
        }
    }

    //ｵﾌﾟｼｮﾝ画面を閉じる
    public void CloseOpstion()
    {
        if (!playEnd)
        {
            //ｵﾌﾞｼﾞｪｸﾄの非表示
            CanvasObject.SetActive(false);
            var player = GameObject.Find("Nezuko");
            player.GetComponent<FPCharacterController>().enabled = true;

            //導蟲の非表示
            mouseFollow.mouseFlag = false;

            //そして時は動き出す。
            Time.timeScale = 1;
        }
    }

    IEnumerator moveTime()
    {
        //3秒待機
        yield return new WaitForSecondsRealtime(3.1f);
        Time.timeScale = 1;

        GameEventMessage.SendEvent("TutorialSound");

    }
}
