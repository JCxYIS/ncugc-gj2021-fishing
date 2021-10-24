using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static string Version => "v.0.0";
    
    public static int Money
    {
        get
        {
            return PlayerPrefs.GetInt("ShutUpAndTakeMy", 0);
        }
        set
        {
            PlayerPrefs.SetInt("ShutUpAndTakeMy", value);
        }
    }

    public static bool UseGyro
    {
        get
        {
            return PlayerPrefs.GetInt("CtrlMeth", 0) != 0;
        }
        set
        {
            PlayerPrefs.SetInt("CtrlMeth", value? 1 : 0);
        }
    }
}