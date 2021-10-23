using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightDecentController : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField] Light2D light;

    public float _decentRate;

    public static float CurrentDensity;


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDensity = 1f + _decentRate * cameraTransform.position.y;
        light.intensity = CurrentDensity;
        if(light.intensity < 0)
            light.intensity = 0;
    }
}
