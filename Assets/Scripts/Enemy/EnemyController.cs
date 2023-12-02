using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField]
        private Transform playerTransform;
        
        [Header("Movement")]
        [SerializeField]
        private float walkSpeed = 10f;
        [SerializeField]
        private Transform[] patrolPoints;
        [SerializeField]
        private float idleTime;
        [SerializeField]
        private float remainingDistance;
        
        [Header("Pursue Player")]
        [SerializeField]
        private float minDistance = 10f;
        [SerializeField]
        private float pursueSpeed = 10f;
        
        

        private float remainingIdle;
        private int currentPatrolIndex = 0;
        private Vector3 currentTarget;
        private Animator animator;
        private bool isIdle= true;
        private bool isPursuing = false;
        
        
        private void Start()
        {
            animator = GetComponent<Animator>();
            remainingIdle = idleTime;
        }

        private void Update()
        {
            Idle();
            Patrol();
            CheckForPlayer();
            PursuePlayer();
        }

        void Patrol()
        {
            if (!isIdle && !isPursuing)
            {
                agent.speed = walkSpeed;
                agent.destination = currentTarget;
                agent.stoppingDistance = remainingDistance;
                
                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            
                            agent.isStopped = true;
                            remainingIdle = idleTime;
                            isIdle = true;
                            animator.SetBool("isIdling", true);
                        }
                    }
                }
            }
            
        }

        void Idle()
        {
            if (isIdle && !isPursuing)
            {
                remainingIdle -= Time.deltaTime;
                if (remainingIdle <= 0)
                {
                    if (currentPatrolIndex + 1 == patrolPoints.Length)
                    {
                        currentPatrolIndex = 0;
                        currentTarget = new Vector3(patrolPoints[0].position.x, transform.position.y, patrolPoints[0].position.z);
                    }
                    else
                    {
                        currentPatrolIndex += 1;
                        currentTarget = new Vector3(patrolPoints[currentPatrolIndex].position.x, transform.position.y, patrolPoints[currentPatrolIndex].position.z);
                    }
                    
                    isIdle = false;
                    animator.SetBool("isIdling", false);
                    
                    agent.isStopped = false;
                }
            }
        }

        void CheckForPlayer()
        {
            if (Vector3.Distance(transform.position, playerTransform.position) <= minDistance)
            {
                isPursuing = true;
                
                animator.SetBool("isPursuing", true);
            }
            else if(isPursuing && Vector3.Distance(transform.position, playerTransform.position) > minDistance)
            {
                animator.SetBool("isPursuing", false);
                isPursuing = false;
                isIdle = false;
                currentTarget = new Vector3(patrolPoints[currentPatrolIndex].position.x, transform.position.y, patrolPoints[currentPatrolIndex].position.z);
            }
        }

        void PursuePlayer()
        {
            if (isPursuing)
            {
                agent.isStopped = false;
                agent.speed = pursueSpeed;
                currentTarget = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.transform.position.z);
                agent.destination = currentTarget;
                
            }
        }

    }
}
