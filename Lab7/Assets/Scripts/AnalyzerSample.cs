using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyzerSample : MonoBehaviour
{
    public void OnButtonPressed()
    {
        Analytics.CustomEvent("StartButtonPressed");
    }
}
