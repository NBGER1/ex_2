using Services;
using UnityEngine;

namespace DefaultNamespace
{
    public class Entrypoint : MonoBehaviour
    {
        private void Awake()
        {
            GameplayServices.Initialize();
        }
    }
}