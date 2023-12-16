using System;
using Enemy;
using UnityEngine;
namespace Player
{
    public class MagicBallController : MonoBehaviour
    {
        [SerializeField]
        private float timeDuration = 8f;
        [SerializeField]
        private GameObject explotion;
        private float damage;

        private EnemyHealth enemyHealth;
        
        public void SetDamage(float newDamage)
        {
            damage = newDamage;
        }

        private void Update()
        {
            timeDuration -= Time.deltaTime;
            if (timeDuration <= 0)
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Message"))
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDamage(damage);
                }
                GameObject exp = Instantiate(explotion, transform);
                exp.transform.SetParent(null);
                Destroy(gameObject);
                
            }
        }



    }
}
