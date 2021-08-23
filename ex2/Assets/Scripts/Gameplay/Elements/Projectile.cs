using System;
using System.Security.Cryptography;
using DefaultNamespace.ScriptableObjects;
using Factories;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Gameplay.Elements
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        #region Editor

        [SerializeField] private ProjectileParams _params;

        [SerializeField] private Rigidbody _rb;
        private Transform _selfTransform;
        private Vector3 _startPoint;

        #endregion

        #region Methods

        private void Awake()
        {
            _selfTransform = transform;
        }

        public void Launch(Quaternion launchRotation)
        {
            _selfTransform.rotation = launchRotation;
            _startPoint = _selfTransform.position;
        }

        private void FixedUpdate()
        {
            _rb.velocity = _selfTransform.forward * _params.Speed;
            if (Vector3.Distance(_startPoint, _selfTransform.position) > _params.MaxDistance) Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(_params.COLLISION_TAG))
            {
                Destroy(gameObject);
            }
        }

// Layermask --> dont hit other projectiles

        #endregion
    }
}