using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaveLoadManager : MonoBehaviour
{
    // Holds level end pivot points and 
    public static LevelSaveLoadManager instance;

    private Transform EndLevelPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator LoadNextLevel()
    {
        Debug.Log("Loading Next Level");
        EndLevelPoint = gameObject.transform.GetChild(1).GetChild(0);
        Instantiate(Resources.Load("Levels/" + (PlayerPrefs.GetInt("Level") % 4).ToString()), EndLevelPoint.position, EndLevelPoint.transform.rotation, gameObject.transform);

        yield return new WaitForSeconds(1);
        Destroy(gameObject.transform.GetChild(0).gameObject);
        GameEvents.instance.ObjectCollected("0");

        
    }


}
