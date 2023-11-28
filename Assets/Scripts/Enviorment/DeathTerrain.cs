using System;
using System.Collections;
using System.Collections.Generic;
using Enviorment;
using UnityEngine;

public class DeathTerrain : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameController gameController;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameController.RestartObjects();
        }
    }
}
