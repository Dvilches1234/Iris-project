using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enviorment
{
    public class EarthPlatformController : MonoBehaviour
    {

        [SerializeField]
        private Transform targetPoint;
        [SerializeField]
        private float movementSpeed = 10f;
        private Vector3 originalPos;

        private bool onTarget = false;
        private bool moving = false;

        private Vector3 targetPos;
        
        // Start is called before the first frame update
        void Start()
        {
            originalPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        void Move()
        {
            if (moving)
            {
             transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
             if (transform.position == targetPos)
             {
                 moving = false;
                 onTarget = !onTarget;
             }
            }
            
        }
        public void GlowPlatform()
        {
        
        }

        public void ActivateMovement()
        {
            moving = true;
            targetPos = onTarget ? originalPos : targetPoint.position;
        }
        
        
        
    } 
}

