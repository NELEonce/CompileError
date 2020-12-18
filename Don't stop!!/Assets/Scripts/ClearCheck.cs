using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    void OnCollisionEnter(Collision collision)
    {
        //ﾌﾟﾚｲﾔｰﾀｸﾞと衝突したら
        if (collision.gameObject.tag == "Player")
        {
            //ゲームが終わる
            gameManager.playEnd = true;
        }
    }
}

