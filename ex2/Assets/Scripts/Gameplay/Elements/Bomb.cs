using System.Linq;
using DefaultNamespace.ScriptableObjects;
using Factories;
using Notifications;
using Services;
using UnityEngine;

namespace Gameplay.Elements
{
    public class Bomb : MonoBehaviour, IProjectile
    {
        #region Editor

        [SerializeField] private ProjectileParams _params;

        [SerializeField] private Rigidbody _rb;
        private Transform _selfTransform;
        private Vector3 _startPoint;

        #endregion

        #region Fields

        private bool _isWarmingUp = true;

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
            GameplayServices.WaitService.WaitFor(_params.WarmUpTime, () =>
            {
                _isWarmingUp = false;
                //# Event Handling
                GameplayServices.EventBus.Publish(GameplayEventType.RocketLaunched,
                    new RocketLaunchedEventParams(_params.ProjectileName, _startPoint));
                _rb.AddRelativeForce((Vector3.up + Vector3.forward) * _params.Speed);
            });
        }

        private void FixedUpdate()
        {
            if (_isWarmingUp) return;
            if (Vector3.Distance(_startPoint, _selfTransform.position) > _params.MaxDistance) Destroy(gameObject);
            _selfTransform.Rotate(Vector3.left, 180f * Time.deltaTime);
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