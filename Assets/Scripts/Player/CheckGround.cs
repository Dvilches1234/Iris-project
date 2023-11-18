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
        void Start()
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
            walkablesTags = playerMovement.GetWalkablesTags();
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
