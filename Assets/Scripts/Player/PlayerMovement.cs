using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Animator playerAnimator;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Collider feetCollider;
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

        private Rigidbody playerRigidBody;
        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            lastDirection = 1;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Jump();
            CheckFalling();
        }

        void Move()
        {
            input.x = Input.GetAxisRaw("Horizontal");
            if (input.x != 0 && isGrounded)
            {
                playerAnimator.SetBool("isMoving", true);
                if (lastDirection != input.x)
                {
                    playerTransform.Rotate(Vector3.up, 180);
                }
                lastDirection = input.x;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + input, movementSpeed * Time.deltaTime);

            }
            else
            {
                playerAnimator.SetBool("isMoving", false);
            }

        }

        void Jump()
        {
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                playerAnimator.SetTrigger("Jump");
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        void CheckFalling()
        {
            if (playerRigidBody.velocity.z < 0)
            {
                playerAnimator.SetTrigger("Falling");
            }
        }


        public void CheckGround(bool value)
        { 
            isGrounded = value;
        }
        public void AddJumpForce()
        {
           
        }
        public float GetJumpForce()
        {
            return jumpForce;
        }


    }  
}

