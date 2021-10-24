using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _controlMethodDropdown;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        // gameObject.SetActive(false);
        // transform.localScale = Vector3.zero;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _controlMethodDropdown.options = new List<TMP_Dropdown.OptionData>{
            new TMP_Dropdown.OptionData("Use Cursor Movement"),
        };
        if(SystemInfo.supportsGyroscope)
            _controlMethodDropdown.AddOptions(new List<TMP_Dropdown.OptionData>(){
                new TMP_Dropdown.OptionData("Use Gyro")
            });
        _controlMethodDropdown.onValueChanged.AddListener(val =>  GameManager.UseGyro = val != 0);
    }


    public void Toggle(bool active)
    {
        if(active)
        {            
            gameObject.SetActive(true);
        }

        transform.DOScale(active?Vector3.one:Vector3.zero, 0.39f).SetEase(Ease.OutElastic);
    }
}