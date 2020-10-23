using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    private ParticleSystem ps;
    private 
 
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        this.transform.position = new Vector3(mousePos.x+0.3f, mousePos.y-0.3f, mousePos.z);

        /*
        // 一つ一つの位置を取得
        ParticleSystem.Particle[] mps = new ParticleSystem.Particle[ps.emission.burstCount];
        ps.GetParticles(mps);
        foreach (var p in mps)
        {
            if ()
            {

            }
        }
        */
    }
}
