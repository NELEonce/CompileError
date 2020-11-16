using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BG_Canvas;

    private void Awake()
    {
        // ﾌﾟﾚｲ中から戻ってきた際にtimeScaleを戻すため
        Time.timeScale = 1;
    }

    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene SelectScene, LoadSceneMode arg1)
    {
        //Select画面に遷移したら　BGオブジェクトを生成する
        if (SelectScene.name == "Select")
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            GameObject mainCamera = GameObject.Find("Main Camera");
            if (mainCamera != null)
                BG_Canvas.GetComponent<Canvas>().worldCamera = mainCamera.GetComponent<Camera>();
            Instantiate(BG_Canvas);
        }
    }
}
