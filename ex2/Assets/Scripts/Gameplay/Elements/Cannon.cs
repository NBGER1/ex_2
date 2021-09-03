using Core;
using DefaultNamespace.Gameplay;
using Factories;
using Notifications;
using Services;
using UnityEngine;

namespace Gameplay.Elements
{
    [RequireComponent(typeof(Animator))]
    public class Cannon : MonoBehaviour, ICannon
    {
        #region Consts

        private const string LAUNCH_ANIMATOR_TRIGGER_NAME = "Fire";

        #endregion

        #region Editor

        [SerializeField] private Transform _rotateTransform;


        [SerializeField] private Animator _cannonAnimator;

        [SerializeField] private Transform _launchProjectilePivotL;

        [SerializeField] private Transform _launchProjectilePivotR;

        #endregion

        #region Fields

        private CannonParams _params;

        private float _angleFactor = 0f;

        private float _angleFactorIncrement;

        private int _launchTriggerHash;
        private ProjectileFactoryBase _projectileFactory;
        private bool _isInitialized = false;

        #endregion

        #region Methods

        private void OnRocketLaunched(EventParams e)
        {
            var eParams = e as RocketLaunchedEventParams;
            Debug.Log($"OnRocketLaunched | Origin: {eParams?.Origin} | Projectile Name: {eParams?.ProjectileName}");
        }

        private void Awake()
        {
            _launchTriggerHash = Animator.StringToHash(LAUNCH_ANIMATOR_TRIGGER_NAME);
        }

        private void Update()
        {
            if (!_isInitialized) return;
            HandleTurretRotation();
        }

        private void HandleTurretRotation()
        {
            _angleFactor = Mathf.Clamp(_angleFactor + _angleFactorIncrement * Time.deltaTime, -1, 1);
            var angleInDegrees = _params.MaxRotationAngle * _angleFactor;
            var cannonDirection = Quaternion.AngleAxis(angleInDegrees, _rotateTransform.up);
            _rotateTransform.localRotation = cannonDirection;
        }

        public void SetRotationForce(float force)
        {
            _angleFactorIncrement = (force * _params.RotationSpeed * _params.RotationSpeedFactor);
        }

        public void Fire()
        {
            if (IsInCooldown) return;
            IsInCooldown = true;


            _cannonAnimator.SetTrigger(_launchTriggerHash);
            var pL = _projectileFactory.Create(_launchProjectilePivotL.position);
            pL.Launch(_launchProjectilePivotL.rotation);
            var pR = _projectileFactory.Create(_launchProjectilePivotR.position);
            pR.Launch(_launchProjectilePivotR.rotation);

            GameplayServices.WaitService
                .WaitFor(_params.CooldownDuration)
                .OnStart(() => Debug.Log("Cooldown Start"))
                .OnProgress(progress => Debug.Log("Cooldown progress: " + progress))
                .OnEnd(() => IsInCooldown = false);
        }

        public void Init(CannonParams cannonParams, ProjectileFactoryBase projectileFactory)
        {
            _params = cannonParams;
            _projectileFactory = projectileFactory;
            GameplayServices.EventBus.Subscribe(GameplayEventType.RocketLaunched, OnRocketLaunched);
            _isInitialized = true;
        }

        #region Properties

        public bool IsInCooldown { get; private set; }

        #endregion

        #endregion
    }
}