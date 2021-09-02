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

        private const string LAUNCH_ANIMATOR_TRIGGER_NAME = "Fire";

        #endregion

        #region Editor

        [SerializeField] private CannonParams _params;

        [SerializeField] private Transform _rotateTransform;


        [SerializeField] private Animator _cannonAnimator;

        [SerializeField] private Transform _launchProjectilePivotL;

        [SerializeField] private Transform _launchProjectilePivotR;

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
            var pL = GameplayElements.Instance.BombFactory.Create(_launchProjectilePivotL.position);
            pL.Launch(_launchProjectilePivotL.rotation);
            var pR = GameplayElements.Instance.BombFactory.Create(_launchProjectilePivotR.position);
            pR.Launch(_launchProjectilePivotR.rotation);

            GameplayServices.WaitService
                .WaitFor(_params.CooldownDuration)
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