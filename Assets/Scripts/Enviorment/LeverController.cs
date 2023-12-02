using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actions;
using Unity.VisualScripting;

namespace Enviorment
{
  public class LeverController : MonoBehaviour
  {
      // Start is called before the first frame update
      
      [SerializeField]
      private ActionController actionController;
      private GlowAtPoint glow;
      private Animator animator;
  
      private bool nearPlayer = false;
      void Start()
      {
          glow = GetComponent<GlowAtPoint>();
          animator = GetComponent<Animator>();
      }
  
      // Update is called once per frame
      void Update()
      {
          if (nearPlayer && Input.GetButtonDown("Fire2"))
          {
              animator.SetTrigger("ActivateLever");
              actionController.Action();
          }
      }
      
      private void OnTriggerEnter(Collider other)
      {
          if (other.gameObject.CompareTag("Player"))
          {
              glow.GlowObjectNoCooldown();
              nearPlayer = true;
          }
      }
      private void OnTriggerExit(Collider other)
      {
          if (other.gameObject.CompareTag("Player"))
          {
              glow.DeactivateGlow();
              nearPlayer = false;
          }
      }
  
      public void Reset()
      {
          actionController.Reset();
      }
  }  
}

