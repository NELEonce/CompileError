using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;     

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BG_Canvas;

    

    void Start()
    {
        Time.timeScale = 1;
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene SelectScene, LoadSceneMode arg1)
    {
        //ｾﾚｸﾄｼｰﾝに遷移したら生成する
        if (SelectScene.name == "Select")
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            GameObject mainCamera = GameObject.Find("Main Camera");
            //背景ｵﾌﾞｼﾞｪｸﾄが無かったら生成する
            if (mainCamera != null)
                BG_Canvas.GetComponent<Canvas>().worldCamera = mainCamera.GetComponent<Camera>();
                Instantiate(BG_Canvas);
        }
    }
}
