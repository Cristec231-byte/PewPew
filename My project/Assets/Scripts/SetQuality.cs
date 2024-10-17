using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetQuality : MonoBehaviour
{
    // Methods to set specific quality levels
    public void SetQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void SetLowQuality()
    {
        SetQualityLevel(0); // Low quality setting
    }

    public void SetMediumQuality()
    {
        SetQualityLevel(3); // Medium quality setting
    }

    public void SetHighQuality()
    {
        SetQualityLevel(5); // High quality setting
    }
}
