using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField]
    private Vector2 offset = Vector2.zero;

    private GameObject scoutflies;  //導蟲
    private Canvas canvas;

    public bool mouseFlag;

    private void Awake()
    {
        //どこでも導蟲
        DontDestroyOnLoad(this.gameObject);
        scoutflies = transform.GetChild(0).gameObject;
        canvas = GetComponent<Canvas>();
        mouseFlag = true;
    }

    private void Update()
    {
        if (canvas.worldCamera == null)
        {
            transform.position = Vector3.zero;
            canvas.worldCamera = GameObject.Find("SubCamera").GetComponent<Camera>();
        }


        if (mouseFlag && !scoutflies.activeSelf)
        {
            // ｶｰｿﾙを表示し、ﾛｯｸを解除する
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            //導蟲表示
            scoutflies.SetActive(true);
        }
        else if (!mouseFlag && scoutflies.activeSelf)
        {
            // ｶｰｿﾙを非表示し、ﾛｯｸする
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //導蟲非表示
            scoutflies.SetActive(false);
        }

        //ﾏｳｽに追従
        var mousePos = Input.mousePosition;
        mousePos = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, mousePos.z);
        mousePos.z = 10.0f;
        mousePos = canvas.worldCamera.ScreenToWorldPoint(mousePos);
        scoutflies.transform.position = new Vector3(mousePos.x, mousePos.y, mousePos.z);
    }
}
