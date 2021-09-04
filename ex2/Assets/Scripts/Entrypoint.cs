using Services;
using UnityEngine;

namespace DefaultNamespace
{
    public class Entrypoint : MonoBehaviour
    {
        #region Methods

        private void Awake()
        {
            GameplayServices.Initialize();
        }

        #endregion
    }
}