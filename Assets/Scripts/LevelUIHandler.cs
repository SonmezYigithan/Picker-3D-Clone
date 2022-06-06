using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIHandler : MonoBehaviour
{
    private int level;
    [SerializeField] TMP_Text levelTxt;
    [SerializeField] GameObject levelFailedPanel;
    [SerializeField] GameObject levelCompletedPanel;

    void Start()
    {
        GameEvents.instance.onLevelPassed += UpdateLevelUI;
        GameEvents.instance.onLevelFailed += ShowLevelFailedPanel;

        levelTxt.text = "LEVEL " + PlayerPrefs.GetInt("Level",1).ToString();
    }

    #region UI

    void UpdateLevelUI()
    {
        levelTxt.text = "LEVEL " + PlayerPrefs.GetInt("Level", 1).ToString();
        levelCompletedPanel.SetActive(true);
    }

    void ShowLevelFailedPanel()
    {
        levelFailedPanel.SetActive(true);
    }

    #endregion

    #region Buttons

    public void RetryButton()
    {
        GameManager.instance.RetryLevel();
    }

    public void ContinueButton()
    {
        levelCompletedPanel.SetActive(false);
        GameManager.instance.ContinueNextLevel();
        Debug.Log("ContinueButton");
    }

    #endregion


}
