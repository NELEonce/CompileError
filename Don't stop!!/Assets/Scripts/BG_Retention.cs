using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BG_Retention : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene nextScene, LoadSceneMode arg1)
    {
        //Practice画面に遷移したら　BGオブジェクトを壊す
        if (nextScene.name == "Practice")
        {
            SceneManager.sceneLoaded -= SceneLoaded;
            Destroy(gameObject);
        }
   
        GameObject mainCamera = GameObject.Find("Main Camera");
        if(mainCamera!=null)
        canvas.worldCamera = mainCamera.GetComponent<Camera>();
    }
}