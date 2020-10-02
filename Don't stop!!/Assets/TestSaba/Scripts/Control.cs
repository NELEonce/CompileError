using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Controller1 input;

    private void Awake()
    {
        input = new Controller1();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        input.TestPlayer.wasd. += _=> Fire();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
    {
        Debug.Log("fire");
    }

    private void StopFire()
    {

        Debug.Log("stop");
    }
} 
