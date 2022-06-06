using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Load next level on trigger enter
    private GameObject endLevelPivot;

    private void Awake()
    {
        endLevelPivot = transform.parent.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadNextLevel(other.gameObject);
    }

    void LoadNextLevel(GameObject other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(LevelSaveLoadManager.instance.LoadNextLevel());
        }
    }

}
