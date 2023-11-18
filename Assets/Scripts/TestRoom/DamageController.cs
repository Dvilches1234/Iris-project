using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace  TestRoom
{
    public class DamageController : MonoBehaviour
    {

        [SerializeField]
        private float damage = 1;
        [SerializeField]
        private float damageCooldown = 1.3f;

        private float remainingCooldown;
        private bool onCooldown;
        private PlayerResources resources;

        // Update is called once per frame
        void Update()
        {
            if (onCooldown)
            {
                remainingCooldown -= Time.deltaTime;
                if (remainingCooldown <= 0)
                {
                    onCooldown = false;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !onCooldown)
            {
                if (resources == null)
                {
                    resources = other.GetComponent<PlayerResources>();
                }
                onCooldown = true;
                remainingCooldown = damageCooldown;
                resources.TakeDamage(damage);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !onCooldown)
            {
                if (resources == null)
                {
                    resources = other.GetComponent<PlayerResources>();
                }
                onCooldown = true;
                remainingCooldown = damageCooldown;
                resources.TakeDamage(damage);
            }
        }
    }

}
