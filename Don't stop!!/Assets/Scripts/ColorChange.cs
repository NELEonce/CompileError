using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    private RawImage raw;

    [SerializeField]
    [Range(0, 50.0f)]
    private float duration = 1.0f;

    [SerializeField]
    [Range(0,1.0f)]
    private float chroma = 1.0f;

    [SerializeField]
    [Range(0, 1.0f)]
    private float brightness = 1.0f;

    void Start()
    {
        raw = GetComponent<RawImage>();
    }

    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        raw.color = Color.HSVToRGB(amplitude, chroma, brightness);
    }
}
