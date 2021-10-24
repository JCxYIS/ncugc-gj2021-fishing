using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class TestGyro : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    Quaternion originGyro = Quaternion.identity;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 1/30f;
        
        print(Input.gyro.attitude);
        Quaternion currentGyro = Input.gyro.attitude;
        Quaternion eliminationOfXY = Quaternion.Inverse(
            Quaternion.FromToRotation(originGyro * Vector3.forward, 
                                    currentGyro * Vector3.forward)
        );
        Quaternion rotationZ = eliminationOfXY * currentGyro;
        float rotation = rotationZ.eulerAngles.z;
        // float rotation = Quaternion.Angle(originGyro, currentGyro);
        // print(rotation);
        text.text = rotation.ToString("0.0");
    }
}