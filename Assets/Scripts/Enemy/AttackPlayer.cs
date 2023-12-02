using System;
using Player;
using UnityEngine;
namespace Enemy
{
    public class AttackPlayer : MonoBehaviour
    {
        [SerializeField]
        float attackCooldown = 0.7f;
        [SerializeField]
        private float damage = 1f;

        private float remainingCooldown;
        private bool isCooldown = false;
        private PlayerResources playerResources;
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
                Debug.Log("attacking");
                playerResources = other.gameObject.GetComponent<PlayerResources>();
                playerResources.TakeDamage(damage);
                isCooldown = true;
                remainingCooldown = attackCooldown;
            }
        }
    }
}
