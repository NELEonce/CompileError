using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Fire", 0, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("Reload", 0, 0.0f);
        }
    }
}
