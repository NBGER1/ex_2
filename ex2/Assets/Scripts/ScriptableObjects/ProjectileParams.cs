using System;
using UnityEngine;

namespace DefaultNamespace.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Gameplay/Projectile/Params", fileName = "Projectile Params")]
    public class ProjectileParams : ScriptableObject
    {
        [Range(0.1f, 100f)] [SerializeField] private float _speed;
        [SerializeField] private string[] _collisionTags;
        [SerializeField] [Range(1, 100)] private float _maxDistance;
        [SerializeField] [Range(0, 1)] private float _mass = 1;
        [SerializeField] [Range(0, 10)] private float _warmUpTime = 0;
        [SerializeField] private Vector3 _modelScale = new Vector3(1, 1, 1);
        [SerializeField] private string _projectileName;
        public float Speed => _speed;
        public string[] COLLISION_TAGS => _collisionTags;
        public float MaxDistance => _maxDistance;
        public float Mass => _mass;
        public float WarmUpTime => _warmUpTime;
        public Vector3 ModelScale => _modelScale;
        public string ProjectileName => _projectileName;
    }
}