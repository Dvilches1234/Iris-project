using System;
using UnityEngine;
namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField]
        private float ballSpeed = 10;
        [SerializeField]
        private float damage = 1f;
        [SerializeField]
        private float shootCooldown;
        [SerializeField]
        private Transform shootingPoint;
        [SerializeField]
        private Transform playerBack;
        [SerializeField]
        private GameObject magicBall;
        [SerializeField]
        private Animator playerAnimator;
        [SerializeField]
        private AudioClip shootSound;
        
        private Vector3 direction;
        private float distance;
        private Vector3 newShootingPos;
        private Rigidbody ballRigidyBody;
        private GameObject newBall;
        private Transform ballTransform;
        private MagicBallController ballController;
        private AudioSource source;
        private bool isCooldown = false;
        private float remainingCooldown;

        private void Start()
        {
            source = GetComponent<AudioSource>();
            distance = Vector3.Distance(shootingPoint.position, playerBack.position);

        }
        private void Update()
        {
            Shoot();
            if (isCooldown)
            {
                remainingCooldown -= Time.deltaTime;
                if (remainingCooldown <= 0)
                {
                    isCooldown = false;
                }
            }
        }

        void Shoot()
        {
            if (Input.GetButtonDown("Fire1") && !isCooldown)
            {
                source.clip = shootSound;
                source.Play();
                    
                playerAnimator.SetTrigger("Attack1");
                direction = shootingPoint.position  - playerBack.position;
                direction = direction.normalized;
                direction.y = 0;
                Debug.Log(direction);
                newBall = Instantiate(magicBall, shootingPoint);
                ballRigidyBody = newBall.GetComponent<Rigidbody>();
                ballTransform = newBall.GetComponent<Transform>();
                ballController = newBall.GetComponent<MagicBallController>();
                ballTransform.SetParent(null);
                ballRigidyBody.velocity = direction * ballSpeed;
                ballController.SetDamage(damage);
                isCooldown = true;
                remainingCooldown = shootCooldown;
                 
            }
        }

       
        
    }
}
