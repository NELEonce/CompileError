using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene SelectScene, LoadSceneMode arg1)
    {
        GameObject BG_Canvas = GameObject.Find("BG_Canvas");
        //Select画面に遷移したら　BGオブジェクトを生成する
        if (SelectScene.name == "Select")
        {
            Instantiate(BG_Canvas);
        }
    }
}
