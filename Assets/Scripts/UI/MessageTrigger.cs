using System;
using UnityEngine;
namespace UI
{
    public class MessageTrigger : MonoBehaviour
    {
        [SerializeField]
        private string message;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AlertText.AlertMessage(message);
            }
        }
    }
}
