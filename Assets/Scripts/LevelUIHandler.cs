using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIHandler : MonoBehaviour
{
    private int level;
    [SerializeField] TMP_Text levelTxt;
    [SerializeField] GameObject levelFailedPanel;

    void Start()
    {
        GameEvents.instance.onLevelPassed += UpdateLevelUI;
        GameEvents.instance.onLevelFailed += ShowLevelFailedPanel;

        levelTxt.text = "LEVEL " + PlayerPrefs.GetInt("Level",1).ToString();
    }

    void UpdateLevelUI()
    {
        levelTxt.text = "LEVEL " + PlayerPrefs.GetInt("Level", 1).ToString();
    }

    void ShowLevelFailedPanel()
    {
        levelFailedPanel.SetActive(true);
    }

    #region Buttons

    public void RetryButton()
    {
        GameManager.instance.RetryLevel();
    }

    #endregion


}
