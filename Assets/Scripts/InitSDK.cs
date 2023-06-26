using AppsFlyerSDK;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.Networking.Types;

public class InitSDK : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AppsFlyerObjectScript _appsFlyer;

    private Dictionary<string, object> _conversionData = new();

    private static string Data = "Data";

    private void Start()
    {
        _appsFlyer.onConversionDataSuccess(Data);
       _conversionData = AppsFlyer.CallbackStringToDictionary(Data);

        if (_conversionData == null)
        {
            return;
        }

        foreach (var item in _conversionData)
        {
            _text.text += item;
        }
    }
  
}
