using System;
using TMPro;
using UnityEngine;
namespace UI
{
    public class AlertText : MonoBehaviour
    {
        
        static GameObject alertPanel;
        static TextMeshProUGUI alertText;
        static float textDuration = 5;
        static float remainingTime;
        static bool activeMessage = false;
        private void Start()
        {
            alertPanel = GameObject.FindWithTag("AlertText");
            alertText = alertPanel.GetComponentInChildren<TextMeshProUGUI>();
            alertPanel.SetActive(false);
        }
        private void Update()
        {
            if (activeMessage)
            {
                remainingTime -= Time.deltaTime;
                if (remainingTime <= 0)
                {
                    alertPanel.SetActive(false);
                    activeMessage = false;
                }
            }
        }

        public static void AlertMessage(string message)
        {
            alertPanel.SetActive(true);
            activeMessage = true;
            remainingTime = textDuration;
            alertText.text = message;
        }
    }
}
