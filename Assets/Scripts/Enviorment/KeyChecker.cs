using System;
using UI;
using UnityEngine;
namespace Enviorment
{
    public class KeyChecker : MonoBehaviour
    {

        [SerializeField]
        private PointsController pointsController;
        [SerializeField]
        private string message;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") || !pointsController.KeysTaken())
            {
                AlertText.AlertMessage(message);
            }
        }

    }
}
