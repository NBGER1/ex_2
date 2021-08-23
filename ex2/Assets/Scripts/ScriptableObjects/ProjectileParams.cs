using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/Projectile/Params", fileName = "Projectile Params")]
    public class ProjectileParams : ScriptableObject
    {
        [Range(0.1f, 2f)]
        [SerializeField]
        private float _speed = 0.1f;

        public float Speed => _speed;
    }
}