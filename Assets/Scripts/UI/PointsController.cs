using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace UI
{
    public class PointsController : MonoBehaviour
    {
        [Header("Keys")]
        [SerializeField]
        private int totalKeys = 5;
        
        [SerializeField]
        private TextMeshProUGUI keysText;
        [Header("Gems")]
        [SerializeField]
        private GameObject gem;
        [SerializeField]
        private int totalGems = 1;
        [SerializeField]
        private TextMeshProUGUI gemsText;
        [SerializeField]
        private GameObject winText;

        private int actualGems = 0;
        int actualKeys = 0;
        
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void AddKey()
        {
            actualKeys += 1;
            keysText.text = actualKeys + "/" + totalKeys;
            if (actualKeys == totalKeys)
            {
                gem.SetActive(true);
            }
        }

        public void AddGem()
        {
            actualGems++;
            gemsText.text = actualGems + "/" + totalGems;
            if (actualGems == totalGems)
            {
                winText.SetActive(true);
            }
        }
        
        
    }   
}

