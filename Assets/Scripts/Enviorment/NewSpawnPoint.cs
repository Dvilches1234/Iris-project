using System;
using UnityEngine;
using UI;
namespace Enviorment
{
    public class NewSpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private GameController gameController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameController.SetNewSpawnPoint(transform);
                AlertText.AlertMessage("Nuevo checkpoint alcanzado");
                
            }
        }
    }
}
