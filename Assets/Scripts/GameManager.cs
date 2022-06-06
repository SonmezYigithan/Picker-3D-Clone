using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Handle Save System

    public static GameManager instance;

    private GameObject picker;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        picker = GameObject.FindGameObjectWithTag("Player");
    }

    #region LevelStates

    public void LevelCompleted()
    {
        Debug.Log("Level Completed");
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level",1)+1);
        GameEvents.instance.LevelPassed();

    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void ContinueNextLevel()
    {
        picker.GetComponent<PlayerMovement>().MovePicker();
    }

    public void LevelFailed()
    {
        Debug.Log("Level Failed");
        // return picker to the start point

        GameEvents.instance.LevelFailed();

        picker.GetComponent<PlayerMovement>().MovePicker();
    }

    #endregion
}
