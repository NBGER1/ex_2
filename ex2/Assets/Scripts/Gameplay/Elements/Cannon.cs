using Core;
using DefaultNamespace.Gameplay;
using Services;
using UnityEngine;

namespace Gameplay.Elements
{
    [RequireComponent(typeof(Animator))]
    public class Cannon : MonoBehaviour, ICannon
    {
        #region Consts

        private const float ROTATION_SPEED_FACTOR = 0.1f;

        private const string LAUNCH_ANIMATOR_TRIGGER_NAME = "Fire";

        #endregion

        #region Editor

        [SerializeField] private Transform _rotateTransform;

        [SerializeField] [Range(1f, 100f)] private float _speed = 5;

        [SerializeField] [Range(20f, 180f)] private uint _maxRotationAngle = 40;

        [SerializeField] private Animator _cannonAnimator;

        [SerializeField] private Transform _launchProjectilePivotL;

        [SerializeField] private Transform _launchProjectilePivotR;
        [SerializeField] [Range(1f, 3f)] private float _cooldownDuration = 1f;

        #endregion

        #region Fields

        private float _angleFactor = 0f;

        private float _angleFactorIncrement;

        private int _launchTriggerHash;

        #endregion

        #region Methods

        private void Awake()
        {
            _launchTriggerHash = Animator.StringToHash(LAUNCH_ANIMATOR_TRIGGER_NAME);
        }

        private void Update()
        {
            HandleTurretRotation();
        }

        private void HandleTurretRotation()
        {
            _angleFactor = Mathf.Clamp(_angleFactor + _angleFactorIncrement * Time.deltaTime, -1, 1);
            var angleInDegrees = _maxRotationAngle * _angleFactor;
            _rotateTransform.localRotation = Quaternion.AngleAxis(angleInDegrees, _rotateTransform.up);
        }

        public void SetRotationForce(float force)
        {
            _angleFactorIncrement = (force * _speed * ROTATION_SPEED_FACTOR);
        }

        public void Fire()
        {
            if (IsInCooldown) return;
            IsInCooldown = true;


            _cannonAnimator.SetTrigger(_launchTriggerHash);
            var pL = GameplayElements.Instance.ProjectileFactory.Create(_launchProjectilePivotL.position);
            pL.Launch(_launchProjectilePivotL.rotation);
            var pR = GameplayElements.Instance.ProjectileFactory.Create(_launchProjectilePivotR.position);
            pR.Launch(_launchProjectilePivotR.rotation);

            GameplayServices.WaitService
                .WaitFor(_cooldownDuration)
                .OnStart(() => Debug.Log("Cooldown Start"))
                .OnProgress(progress => Debug.Log("Cooldown progress: " + progress))
                .OnEnd(() => IsInCooldown = false);

            //# The code below is to test awaiter exercise only!
            var testWait = 5.8f;
            GameplayServices.WaitService.WaitFor(testWait, () => { Debug.Log($"{testWait} seconds have passed"); });
        }

        #region Properties

        public bool IsInCooldown { get; private set; }

        #endregion

        #endregion
    }
}