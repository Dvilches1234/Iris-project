using System;
using UnityEngine;
namespace Enviorment
{
    public class ExplotionController : MonoBehaviour
    {
        private float time = 2f;

        private void Update()
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
