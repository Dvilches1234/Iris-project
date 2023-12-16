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
        [SerializeField]
        private float timeOnTarget = 5f;
        private Vector3 originalPos;

        private bool onTarget = false;
        private bool moving = false;
        private float remainingTime;
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
            if (onTarget)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0)
                {
                    ActivateMovement();
                    
                }
            }
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
                 remainingTime = timeOnTarget;

             }
            }
            
        }
        public void GlowPlatform()
        {
        
        }
        public bool IsOnTarget()
        {
            return transform.position == targetPos;
        }

        public bool HasPlayer()
        {
            return transform.childCount > 0;
        }
        public void ActivateMovement()
        {
            moving = true;
            targetPos = onTarget ? originalPos : targetPoint.position;
        }
        
        
        
    } 
}

