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
        input.TestPlayer.wasd.performed+= _=> Fire();
        input.TestPlayer.wasd.performed += _ => StopFire();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
    {
        Debug.Log("wasd");
    }

    private void StopFire()
    {

        Debug.Log("wasd");
    }
} 
