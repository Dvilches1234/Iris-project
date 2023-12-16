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

        [Header("Scene Management")]
        [SerializeField]
        private SceneController sceneController;

        private int actualGems = 0;
        int actualKeys = 0;
        private bool won = false;
        private float wonTime = 3f;
        
        void Start()
        {
            if (PlayerPrefsController.IsASave() && PlayerPrefsController.IsOnLevel())
            {
                int[] points = PlayerPrefsController.GetPlayerPoints();
                actualKeys = points[0];
                actualGems = points[1];
                
                keysText.text = actualKeys + "/" + totalKeys;
                
                gemsText.text = actualGems + "/" + totalGems;
                if (actualKeys >= totalKeys)
                {

                    gem.SetActive(true);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (won)
            {
                wonTime -= Time.deltaTime;
                if (wonTime <= 0)
                {
                    sceneController.NextLevel();
                }
            }
        }

        public void AddKey()
        {
            actualKeys += 1;
            
            keysText.text = actualKeys + "/" + totalKeys;
            if (actualKeys >= totalKeys)
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
                won = true;
            }
        }

        public void Reset()
        {
            actualKeys = 0;
            actualGems = 0;
            
            keysText.text = actualKeys + "/" + totalKeys;
            gemsText.text = actualGems + "/" + totalGems;
        }

        public bool KeysTaken()
        {
            return actualKeys >= totalKeys;
        }
        public int[] GetPoints()
        {
            int[] points = new int[2];
            points[0] = actualKeys;
            points[1] = actualGems;
            return points;
        }
        
    }   
}

