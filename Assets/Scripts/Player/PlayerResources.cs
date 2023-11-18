using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace Player
{
    public class PlayerResources:MonoBehaviour
    {
        [SerializeField]
        float totalHealth = 5;
        [SerializeField]
        private float totalMana = 5;
        [SerializeField]
        private ProgressBar healthProgressBar;
        [SerializeField]
        private ProgressBar manaProgressBar;

        private float currentHealth;
        private float currentMana;
        private float healthPercentage;
        private float manaPercentage;
        public void Start()
        {
            currentHealth = totalHealth;
            currentMana = totalMana;
            healthProgressBar.BarValue = 100;
            manaProgressBar.BarValue = 100;

        }

        private void Update()
        {
            
        }

        public void TakeDamage(float damage)
        {
            if (currentHealth - damage > 0)
            {
                currentHealth -= damage;
            }
            else
            {
                currentHealth = 0;
            }
            healthPercentage = currentHealth * 100 / totalHealth;
            healthProgressBar.BarValue = healthPercentage;
        }

        public void Heal(float newHealth)
        {
            if (currentHealth +newHealth < totalHealth)
            {
                currentHealth += newHealth;
            }
            else
            {
                currentHealth = totalHealth;
            }
            healthPercentage = currentHealth * 100 / totalHealth;
            healthProgressBar.BarValue = healthPercentage;
        }

        public void UseMana(float manaUse)
        {
            if (currentHealth - manaUse> 0)
            {
                currentMana -= manaUse;
            }
            else
            {
                currentMana = 0;
            }
            manaPercentage = currentMana * 100 / totalMana;
            manaProgressBar.BarValue = manaPercentage;
        }

        public void RecoverMana(float newMana)
        {
            if (currentHealth + newMana < totalMana)
            {
                currentMana += newMana;
            }
            else
            {
                currentMana = totalMana;
            }
            manaPercentage = currentMana * 100 / totalMana;
            manaProgressBar.BarValue = manaPercentage;
        }

        public float GetCurrentMana()
        {
            return currentMana;
        }


    }
}
