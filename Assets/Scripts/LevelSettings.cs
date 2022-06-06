using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{
    public Level levelSettings;
    
    void Start()
    {
        transform.GetChild(2).GetComponent<HoleManager>().RequiredCollectCount = levelSettings.requiredCollectCount;
        transform.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>().text = "0 / " + levelSettings.requiredCollectCount;

    }
}
