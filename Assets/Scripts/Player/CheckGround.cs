using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CheckGround : MonoBehaviour
    {
        // Start is called before the first frame update
        private PlayerMovement playerMovement;
        void Start()
        {
            playerMovement = GetComponentInParent<PlayerMovement>();
        }

        // Update is called once per frame
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                playerMovement.CheckGround(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                playerMovement.CheckGround(false);
            }
        }
    } 
    
}
