using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action<string> onObjectCollected;
    public event Action onLevelPassed;
    public event Action onLevelFailed;

    public static GameEvents instance;

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

    public void ObjectCollected(string count)
    {
        if (onObjectCollected != null)
        {
            onObjectCollected(count);
        }
    }

    public void LevelPassed()
    {
        if ( onLevelPassed != null)
        {
            onLevelPassed();
        }
    }

    public void LevelFailed()
    {
        if (onLevelFailed != null)
        {
            onLevelFailed();
        }
    }
}
