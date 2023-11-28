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
                playerMovement.CheckGround(true);
            }
            if (platformTags.Contains(other.gameObject.tag))
            {
                parentTransform.parent = other.gameObject.transform;
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
                playerMovement.CheckGround(false);
            }
            
        }  
    } 
    
}
