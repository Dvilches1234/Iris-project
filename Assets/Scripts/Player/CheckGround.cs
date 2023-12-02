using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player
{
    public class CheckGround : MonoBehaviour
    {
        // Start is called before the first frame update
        private PlayerMovement playerMovement;
        
        private string[] walkablesTags;
        private string[] platformTags;
        private Transform parentTransform;
        private GameObject platform;

        private bool grounded = true;
        private bool onNormalGround = true;
        
        void Start()
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
            walkablesTags = playerMovement.GetWalkablesTags();
            platformTags = playerMovement.GetPlatformTags();
            parentTransform = playerMovement.GetTransform();

        }

        private void Update()
        {
            
        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            
            if (walkablesTags.Contains(other.gameObject.tag) )
            {
                grounded = true;
                onNormalGround = true;
                playerMovement.CheckGround(true);
            }
            if (platformTags.Contains(other.gameObject.tag))
            {
                onNormalGround = false;
                parentTransform.parent = other.gameObject.transform;
                platform = other.gameObject;
            }
            else
            {
                parentTransform.parent = null;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (walkablesTags.Contains(other.gameObject.tag))
            {
                playerMovement.CheckGround(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (walkablesTags.Contains(other.gameObject.tag))
            {
                onNormalGround = false;
                grounded = false;
                playerMovement.CheckGround(false);
            }
            
        }  

        public bool IsOnPlatform()
        {
            return grounded && !onNormalGround;
        }
        public GameObject GetCurrentPlatform()
        {
            return platform;
        }
    } 
    
}
