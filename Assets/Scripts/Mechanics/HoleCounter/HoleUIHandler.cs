using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoleUIHandler : MonoBehaviour
{
    // listens onObjectCollected
    [SerializeField] TMP_Text countText;

    private void Start()
    {
        GameEvents.instance.onObjectCollected += UpdateBallCountUI;
    }

    private void UpdateBallCountUI(string count)
    {
        countText.text = count;
    }
}
