using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightDecentController : MonoBehaviour
{
    Transform cameraTransform;
    [SerializeField] Light2D light;

    public float _decentRate;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        light.intensity = 1f + _decentRate * cameraTransform.position.y;
    }
}
