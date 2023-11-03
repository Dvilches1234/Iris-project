using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float movementSpeed = 7f;
    [SerializeField]
    private float movementOnAirSpeed = 3f; 
    [SerializeField]
    private float jumpForce = 7f;
    
    
    
    private Vector3 input;
    private float lastDirection;
    private Vector3 targetPosition;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        lastDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        input.z = Input.GetAxisRaw("Horizontal");
        if (input.z != 0)
        {
            playerAnimator.SetBool("isMoving", true);
            if (lastDirection != input.z)
            {
                playerTransform.Rotate(Vector3.up, 180);
            }
            
            lastDirection = input.z;
            
            
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }

}
