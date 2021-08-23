using DefaultNamespace.ScriptableObjects;
using UnityEngine;

namespace Gameplay.Elements
{
    public class Projectile : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private ProjectileParams _params;

        [SerializeField]
        private Rigidbody _rb;

        #endregion
    }
}