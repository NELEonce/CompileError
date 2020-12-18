using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yugamu : MonoBehaviour
{
    public float lengthScale = 20f;
    public int count = 1000;
    public float repeat = 5f;
    public float radius = 10f;
    public Quaternion angles;
    public Vector3 offset;

    private GameObject insObj;
    private float oneCycle;
    private float oneLength;
    private float z;
    private Transform[] collection;

    private void Start()
    {
        oneCycle = 2.0f * Mathf.PI;

        var obj = transform.Find("Cube").gameObject;
        
        oneLength = transform.localScale.z * lengthScale / count;
        z = transform.localPosition.z - oneLength;

        for (int i = 1; i < count; i++)
        {
            insObj = Instantiate(obj, transform);
            insObj.transform.parent = transform;
            
            var point = ((float)i / count) * oneCycle;
            var repeatPoint = point * repeat; // 繰り返し位置

            var k = ((float)i / count) * oneCycle;

            var x = Mathf.Sin(repeatPoint) * radius;
            var y = Mathf.Cos(repeatPoint) * radius;
            z += oneLength;

            insObj.transform.localPosition = new Vector3(x,y,z);
        }

        collection = transform.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        oneLength = transform.localScale.z * lengthScale / count;
        var def = (2 / count) * oneCycle;
        for (int i = 1; i < collection.Length; i++)
        {
            var point = ((float)i / count) * oneCycle;
            var repeatPoint = point * repeat; // 繰り返し位置

            var x = Mathf.Sin(repeatPoint) * radius;
            var y = Mathf.Cos(repeatPoint) * radius - Mathf.Cos(def) * radius;
            z += oneLength;

            collection[i].localPosition = new Vector3(x, y, z) + offset;
            collection[i].localRotation = collection[i - 1].localRotation * Quaternion.Inverse(angles);
        }
        z = 0;
    }
}
