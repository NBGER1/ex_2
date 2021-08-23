using System;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/Projectile/Params", fileName = "Projectile Params")]
    public class ProjectileParams : ScriptableObject
    {
        [Range(0.1f, 100f)] [SerializeField] private float _speed;
        [SerializeField] private string _collisionTag;
        [SerializeField] [Range(1, 100)] private float _maxDistance;
        public float Speed => _speed;
        public string COLLISION_TAG => _collisionTag;
        public float MaxDistance => _maxDistance;
    }
}