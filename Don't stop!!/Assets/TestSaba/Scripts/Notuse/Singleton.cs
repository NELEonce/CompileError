using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : class, new()
{
    // @brief インスタンス変数への代入が完了するまで、アクセスできなくなるジェネリックなインスタンス
    private static volatile T m_instance;
    // @brief ロックするためのインスタンス
    private static object m_sync_obj = new object();

    // @brief ジェネリックなインスタンス
    public static T Instance
    {
        get
        {
            // ダブルチェック ロッキング アプローチ.
            if (m_instance == null)
            {
                // m_sync_objインスタンスをロックし、この型そのものをロックしないことで、デッドロックの発生を回避
                lock (m_sync_obj)
                {
                    if (m_instance == null)
                    {
                        m_instance = new T();
                    }
                }
            }
            return m_instance;
        }
    }

    // @brief コンストラクタ
    protected Singleton() { }

    
}
