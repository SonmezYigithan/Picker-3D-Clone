using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLine : MonoBehaviour
{
    private HoleManager holeManager;

    private void Awake()
    {
        holeManager = gameObject.transform.parent.GetComponent<HoleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StopPicker(other.gameObject);
    }

    void StopPicker(GameObject other)
    {
        if (other.tag == "Player" && other.GetComponent<PlayerMovement>().moving == true)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            holeManager.isCounting = true;
            other.GetComponent<PlayerMovement>().StopPicker();
            StartCoroutine(holeManager.StartCounting());
            
        }
    }
    
}
