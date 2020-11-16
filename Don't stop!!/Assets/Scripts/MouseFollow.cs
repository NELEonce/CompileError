using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private GameObject sirube;
    private Canvas canvas;

    void Awake()
    {
        //どこでも導蟲
        DontDestroyOnLoad(this.gameObject);
        sirube = transform.GetChild(0).gameObject;
        canvas = GetComponent<Canvas>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (canvas.worldCamera == null)
        {
            transform.position = Vector3.zero;
            canvas.worldCamera = GameObject.Find("SubCamera").GetComponent<Camera>();
        }
        //ﾏｳｽに追従
        var mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = canvas.worldCamera.ScreenToWorldPoint(mousePos);
        sirube.transform.position = new Vector3(mousePos.x + 0.3f, mousePos.y - 0.3f, mousePos.z);
    }
}
