using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine;

public class GameManager : MonoBehaviour
{
    private Controller1 controller;
    private GameObject sirubeMusi;

    [SerializeField] GameObject CanvasObject;

    private void Awake()
    {
        //導蟲取得
        sirubeMusi = GameObject.Find("Particle System");

        controller = new Controller1();

        //Callbackの登録
        controller.Option.Open.started += _ => OpenOpstion();

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

    void Start()
    {
        // ｶｰｿﾙを非表示かつﾛｯｸする
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //ｵﾌﾞｼﾞｪｸﾄの非表示
        CanvasObject.SetActive(false);

        //ゲームが始まったら導蟲を非表示
        sirubeMusi.SetActive(false);
    }


    void Update()
    {
        
    }

    //Escｷｰを押したら
    void OpenOpstion()
    {
        //ｻﾞ・ﾜｰﾙﾄﾞ
        Time.timeScale = 0;

        //ｵﾌﾞｼﾞｪｸﾄの表示
        CanvasObject.SetActive(true);

        // ｶｰｿﾙを表示し、ﾛｯｸを解除する
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        //導蟲の表示
        sirubeMusi.SetActive(true);
    }

    //ｵﾌﾟｼｮﾝ画面を閉じる
    public void CloseOpstion()
    {
        //ｵﾌﾞｼﾞｪｸﾄの非表示
        CanvasObject.SetActive(false);

        // ｶｰｿﾙを非表示かつﾛｯｸする
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //導蟲の非表示
        sirubeMusi.SetActive(false);

        //そして時は動き出す。
        Time.timeScale = 1;
    }

    public void TimeMove()
    {
        Time.timeScale = 1;
    }
}
