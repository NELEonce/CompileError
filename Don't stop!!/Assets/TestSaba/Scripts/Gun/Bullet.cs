using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject hibana;

    [SerializeField]
    private float speed = 1f;

    void Update()
    {
        var oldPos = transform.position;
        transform.position += transform.forward * speed;

        var maxDistance = Vector3.Distance(oldPos, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(oldPos, transform.forward, out hit, maxDistance))
        {
            var dir = transform.rotation * Quaternion.Euler(0, 180.0f, 0);
            Instantiate(hibana, hit.point, dir);
            Destroy(gameObject);
        }

        Invoke("LifeLimit", 3);
    }

    void LifeLimit()
    {
        Destroy(gameObject);
    }
}
