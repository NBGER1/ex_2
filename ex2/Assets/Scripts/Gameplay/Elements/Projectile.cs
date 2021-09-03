using System.Linq;
using DefaultNamespace.ScriptableObjects;
using Factories;
using Notifications;
using Services;
using UnityEngine;

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
            _rb.mass = _params.Mass;
        }

        public void Launch(Quaternion launchRotation)
        {
            _selfTransform.rotation = launchRotation;
            _startPoint = _selfTransform.position;

            //# Event Handling
            GameplayServices.EventBus.Publish(GameplayEventType.RocketLaunched,
                new RocketLaunchedEventParams(_params.ProjectileName, _startPoint));
        }

        private void FixedUpdate()
        {
            _rb.velocity = _selfTransform.forward * _params.Speed;
            if (Vector3.Distance(_startPoint, _selfTransform.position) > _params.MaxDistance) Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_params.COLLISION_TAGS.Contains(other.gameObject.tag))
            {
                UnityEngine.Vector3 collisionPoint = other.contacts[0].point;
                GameplayServices.EventBus.Publish(GameplayEventType.ProjectileHitCar,
                    new ProjectileHitCarEventParams(collisionPoint));
                Destroy(gameObject);
            }
        }

        #endregion
    }
}