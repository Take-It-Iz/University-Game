using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AndroidPlugin : MonoBehaviour
{
    const string JavaClassName = "android.widget.Toast";
    MenuControls sceneSwitch = new MenuControls();

    public void ButtonClickEvent(InputField playerinputName)
	{	        
		var javaClassObject = new AndroidJavaClass(JavaClassName);
		const int duration = 1; 
		string text = playerinputName.text + "! Good Game!"; 
		var context = GetUnityActivity();
		var javaToastObject = javaClassObject.CallStatic<AndroidJavaObject>("makeText", context, text, duration);

        Debug.Log("Rip And Tear");
		javaToastObject.Call("show");	
		javaClassObject.Dispose();
        sceneSwitch.StartGame();
	}

    AndroidJavaObject GetUnityActivity()
	{
		using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
		}
	}
}
