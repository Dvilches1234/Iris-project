using System;
using Player;
using UI;
using UnityEngine;
namespace Enviorment
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Transform spawnPoint;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private PlayerResources playerResources;
        [SerializeField]
        private PointsController pointsController;
        
        
        private GameObject[] keys;
        private GameObject[] levers;

        private LeverController[] leverControllers;

        private void Start()
        {
            keys = GameObject.FindGameObjectsWithTag("Key");
            levers = GameObject.FindGameObjectsWithTag("Lever");
            leverControllers = new LeverController[levers.Length];
            for (int i = 0; i < levers.Length; i++)
            {
                leverControllers[i] = levers[i].GetComponent<LeverController>();
            }
            
        }


        public void RestartObjects()
        {
            foreach (GameObject key in keys)
            {
                key.SetActive(true);
            }
            foreach (LeverController lever in leverControllers)
            {
                lever.Reset();
            }

            playerTransform.position = spawnPoint.position;
            //pointsController.Reset();
            playerResources.Reset();
        }

        public void SetNewSpawnPoint(Transform newSpawnPoint)
        {
            spawnPoint = newSpawnPoint;
        }
    }
}
