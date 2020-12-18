using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mawaru : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField]
    private float i = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.angularVelocity = Vector3.up * i;
    }
}
