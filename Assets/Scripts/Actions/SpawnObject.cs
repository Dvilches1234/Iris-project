using UI;
using UnityEngine;
namespace Actions
{
    public class SpawnObject : ActionController
    {
        [SerializeField]
        GameObject objectToSpawn;
        [SerializeField]
        private string message;
        

        private bool objectSpawned = false;
        public override void Action()
        {
            if (!objectSpawned)
            {
                Instantiate(objectToSpawn, transform).transform.SetParent(null);
                objectSpawned = true;
                AlertText.AlertMessage(message);
            }
        }

        public override void Reset()
        {
            objectSpawned = false;
        }
    }
}
