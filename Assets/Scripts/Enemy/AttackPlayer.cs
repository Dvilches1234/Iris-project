using System;
using Player;
using UnityEngine;
namespace Enemy
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField]
        float attackCooldown = 1f;
        [SerializeField]
        private float damage = 1f;
        [SerializeField]
        private AudioClip attackSound;
        [SerializeField]
        private AudioSource source;
        private float remainingCooldown;
        private bool isCooldown = false;
        private PlayerResources playerResources;

        private void Start()
        {
        }
        private void Update()
        {
            if (isCooldown)
            {
                remainingCooldown -= Time.deltaTime;
                if (remainingCooldown <= 0)
                {
                    isCooldown = false;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isCooldown)
            {
                source.clip = attackSound;
                source.Play();
                playerResources = other.gameObject.GetComponent<PlayerResources>();
                playerResources.TakeDamage(damage);
                isCooldown = true;
                remainingCooldown = attackCooldown;
            }
        }
    }
}
