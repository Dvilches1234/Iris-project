using System;
using UnityEngine;
namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField]
        private float health = 1f;

        private float currentHealth;
        private void Start()
        {
            currentHealth = health;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
            
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}
