using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    // open gates if user collected enough balls
    // Tween hiddenfloor up if user collected enough balls

    public int RequiredCollectCount;
    public float countWaitTime;

    [Header("References")]
    [SerializeField] private GameObject gate1;
    [SerializeField] private GameObject gate2;
    [SerializeField] private GameObject hiddenFloor;
    [SerializeField] private GameObject collectableContainer;

    public bool isCounting = false;

    private int currentCollectCount = 0;

    private void Start()
    {
        DOTween.Init();
    }

    public void ObjectCollected(int count)
    {
        if (isCounting)
        {
            currentCollectCount += 1;
            GameEvents.instance.ObjectCollected((count).ToString() + " / " + RequiredCollectCount);
        }
    }

    void AnimateGates()
    {
        gate1.transform.DORotate(new Vector3(0, 0, 90), 1, RotateMode.Fast);
        gate2.transform.DORotate(new Vector3(0, 0, -90), 1, RotateMode.Fast);
        hiddenFloor.transform.DOMoveY(-0.25f, 2);

        gate1.transform.GetChild(0).GetComponent<Collider>().enabled = false;
        gate2.transform.GetChild(0).GetComponent<Collider>().enabled = false;
    }

    public IEnumerator StartCounting()
    {
        yield return new WaitForSeconds(countWaitTime);
        isCounting = false;

        if (currentCollectCount >= RequiredCollectCount)
        {
            // Level Completed
            DeleteCollectables();
            AnimateGates();
            GameManager.instance.LevelCompleted();
        }
        else
        {
            // level Failed
            GameManager.instance.LevelFailed();
        }
    }

    /// <summary>
    /// Can use destroy effects here in future
    /// </summary>
    public void DeleteCollectables()
    {
        collectableContainer.SetActive(false);
        Destroy(collectableContainer);
    }
}
