using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;


namespace TestRoom
{
    public class HealController : MonoBehaviour
    {
        [SerializeField]
        private float heal;
        [SerializeField]
        private float healCooldown = 1f;

        private bool onCooldown = false;
        private float remainingCooldown;
        private PlayerResources resources;

        private void Update()
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
                remainingCooldown = healCooldown;
                resources.Heal(heal);
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
                remainingCooldown = healCooldown;
                resources.Heal(heal);
            }
        }

    }
  
}
