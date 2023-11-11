using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Animations")]
        [SerializeField]
        private Animator playerAnimator;
        [Header("Dependencies")]
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Transform camTransform;

        
        [Header("Movement")]
        [SerializeField]
        private float movementSpeed = 7f;
        [SerializeField]
        private float turnSmoothTime = 5f;
        /*[SerializeField]
        private float movementOnAirSpeed = 3f;*/
        [SerializeField]
        private float jumpForce = 7f;

        
        private Vector3 input;
        //private float lastDirection;
        private Vector3 targetPosition;
        private bool isGrounded = false;
        private float turnSmoothVelocity;
        private float targetAngle;
        private float angle;
        private Rigidbody playerRigidBody;
        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            Cursor.visible = false;
            
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
            input.z = Input.GetAxisRaw("Vertical");
            input = input.normalized;
            if (input != Vector3.zero)
            {
                playerAnimator.SetBool("isMoving", true);
                
                targetAngle = (Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg) + camTransform.eulerAngles.y;
                angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                // Move the character
                var moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + moveDir, movementSpeed * Time.deltaTime);
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
                /*if(playerAnimator.state)*/
                //playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        void CheckFalling()
        {
            if (playerRigidBody.velocity.y < 0)
            { 
                playerAnimator.SetTrigger("Falling");
            }
        }


        public void CheckGround(bool value)
        { 
            isGrounded = value;
            playerAnimator.SetBool("isGrounded", value);
            Debug.Log("Grounded changed to: " + value);
        }
        public void AddJumpForce()
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        public float GetJumpForce()
        {
            return jumpForce;
        }


    }  
}

