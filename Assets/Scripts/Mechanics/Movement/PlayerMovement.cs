using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    Vector3 endPos;
    Vector3 target;

    float moveFactorX;
    float firstPos;
    private Rigidbody rb;

    [SerializeField] float _xMinClamp = -5.84f;
    [SerializeField] float _xMaxClamp = 6.69f;

    public float swerveSpeed;
    public float forwardSpeed;

    public bool moving = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleSwerveMouseMovement();
    }

    void HandleSwerveMouseMovement()
    {
        if (moving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                moveFactorX = Input.mousePosition.x - firstPos;
                firstPos = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                firstPos = 0f;
                moveFactorX = 0f;
            }

            float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;

            rb.velocity = new Vector3(Mathf.Clamp(swerveAmount, -3.5f, 3.5f), 0, forwardSpeed) * forwardSpeed;
        }        
    }

    public void StopPicker()
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
        moving = false;
    }

    public void MovePicker()
    {
        rb.isKinematic = false;
        moving = true;
    }
}
