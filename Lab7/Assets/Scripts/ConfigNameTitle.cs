using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.UI;

public class ConfigNameTitle : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public string newNameTitle = "Input here:";
    public Text title;
 
    void Awake()
    {
        ConfigManager.FetchCompleted += SetNewNameTitle;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void SetNewNameTitle(ConfigResponse response)
    {
        newNameTitle = ConfigManager.appConfig.GetString("nameTitle");
        title.text = newNameTitle;
    }
}