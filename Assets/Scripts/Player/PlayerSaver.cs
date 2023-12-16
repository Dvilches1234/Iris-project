using System;
using UI;
using UnityEngine;
namespace Player
{
    public class PlayerSaver : MonoBehaviour
    {
        [SerializeField]
        private PointsController pointsController;
        private float savingTime = 20f;
        private float remainingTime;
        
        private PlayerResources resources;
        private int[] points;
        private bool isLoad;
        private void Start()
        {
            resources = GetComponent<PlayerResources>();
            isLoad = PlayerPrefsController.IsASave();
            remainingTime = savingTime;
        }

        private void Update()
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                SaveData();
                remainingTime = savingTime;
            }
        }
        void SaveData()
        {
            if (!isLoad)
            {
                PlayerPrefsController.SetSaved();
                isLoad = true;
            }
            PlayerPrefsController.SavePlayerPos(transform.position);
            points = pointsController.GetPoints();
            PlayerPrefsController.SavePlayerPoints(points[0], points[1]);
            PlayerPrefsController.SavePlayerResources(resources.GetCurrentHealth(), resources.GetCurrentMana());

            PlayerPrefsController.SetOnLevel(true);
        }
        
        
        
        
    }
}
