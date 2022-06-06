using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollectCounter : MonoBehaviour
{
    public int collectableCount;
    private HoleManager holeManager;

    private void Awake()
    {
        holeManager = gameObject.transform.parent.parent.GetComponent<HoleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collectable")
            IncreaseCollectableCount();
    }

    private void IncreaseCollectableCount()
    {
        collectableCount += 1;
        holeManager.ObjectCollected(collectableCount);
    }
}
