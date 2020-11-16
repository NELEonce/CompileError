using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreTime : MonoBehaviour
{
    private ParticleSystem par;

    private void Start()
    {
        par = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        par.Simulate(Time.unscaledDeltaTime, false, false, true);
    }
}
