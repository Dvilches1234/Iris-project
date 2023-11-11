using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
   public class PlayerSkills : MonoBehaviour
   {
       [SerializeField]
       private Transform cameraMain;
       [SerializeField]
       private Transform playerBack;
       [SerializeField]
       private float range = 15f;
       [SerializeField]
       private LayerMask groundLayer;
       private RaycastHit hit;

       private Vector3 direction;
       // Start is called before the first frame update
       void Start()
       {
           
       }
   
       // Update is called once per frame
       void Update()
       {
           CheckElements();
       }

       void CheckElements()
       {
           direction = playerBack.position  - cameraMain.position;
           Debug.DrawRay(playerBack.position, direction, Color.blue);
           if (Physics.Raycast(playerBack.position, direction, out hit, range, groundLayer))
           {
               Debug.Log(hit.collider.name);
               Vector3 direction2 = hit.transform.position - playerBack.position; 
               Debug.DrawRay(playerBack.position, direction2, Color.red);
           }
       }
   } 
}

