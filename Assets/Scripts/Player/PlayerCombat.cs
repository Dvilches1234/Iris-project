using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField]
        private Animator playerAnimator;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
        }

        void Attack()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerAnimator.SetTrigger("Attack1");
            }
        }
    }
   
}
