using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Enviorment
{
    public class KeyController : MonoBehaviour
    {
        // Start is called before the first frame update
        private PointsController pointsController;
        void Start()
        {
            pointsController = GameObject.FindWithTag("PointController").GetComponent<PointsController>();
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                pointsController.AddKey();

                Destroy(gameObject);
            }
        }
    }
}


