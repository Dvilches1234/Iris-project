using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class ManaBottleController : MonoBehaviour
{
    [SerializeField]
    private float manaRecover = 5;
    private PlayerResources resources;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            resources = other.gameObject.GetComponent<PlayerResources>();
            resources.RecoverMana(manaRecover);
            resources.Heal(manaRecover);
            Destroy(gameObject);
        }
    }
}
