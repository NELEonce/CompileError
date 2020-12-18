using UnityEngine;
using System.Collections;
public class Count : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DestroyCoroutine");
    }

    IEnumerator DestroyCoroutine()
    {
        //３秒後にオブジェクトを壊す
        yield return new WaitForSecondsRealtime(3.1f);
        Destroy(this.gameObject);
    }
}
