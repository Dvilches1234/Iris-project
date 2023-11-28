using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enviorment;

namespace Player
{
   public class PlayerSkills : MonoBehaviour
   {
       [SerializeField]
       private Transform cameraMain;
       [SerializeField]
       private Transform playerBack;
       [SerializeField]
       private Animator playerAnimator;
       [SerializeField]
       private float range = 15f;
       [SerializeField]
       private LayerMask groundLayer;
       [SerializeField]
       private LayerMask earthPlatformLayer;
       [Header("EarthPowers")]
       [SerializeField]
       private float earthPowerMana = 1;
       private RaycastHit hit;

       private Vector3 direction;

       private EarthPlatformController currentEarthPlatform;
       private GlowAtPoint glowPoint;
       private PlayerResources resources;
       // Start is called before the first frame update
       void Start()
       {
           resources = GetComponent<PlayerResources>();
           
       }
   
       // Update is called once per frame
       void Update()
       {
           CheckEarthPlatforms();
       }

       void CheckElements()
       {
           direction = playerBack.position  - cameraMain.position;
           if (Physics.Raycast(playerBack.position, direction, out hit, range, earthPlatformLayer))
           {
               //Debug.Log(hit.collider.name);
               Vector3 direction2 = hit.transform.position - playerBack.position; 
               Debug.DrawRay(playerBack.position, direction2, Color.red);
               if (Input.GetButtonDown("Fire1"))
               {
                   playerAnimator.SetTrigger("Attack1");
               }
           }
       }

       void CheckEarthPlatforms()
       {
           direction = playerBack.position  - cameraMain.position;
           if (Physics.Raycast(playerBack.position, direction, out hit, range, earthPlatformLayer))
           {
               Vector3 direction2 = hit.transform.position - playerBack.position;
               if (currentEarthPlatform == null ||currentEarthPlatform.gameObject != hit.collider.gameObject)
               {
                   glowPoint = hit.collider.GetComponent<GlowAtPoint>();
                   currentEarthPlatform = hit.collider.GetComponent<EarthPlatformController>();
               }
               glowPoint.GlowObject();
               
               if (Input.GetButtonDown("Fire1") && resources.GetCurrentMana() - earthPowerMana >=0 )
               {
                   playerAnimator.SetTrigger("Attack1");
                   currentEarthPlatform.ActivateMovement();
                   resources.UseMana(earthPowerMana);
               }
           }
       }
   } 
}

