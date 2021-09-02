using Core;
using DefaultNamespace.Gameplay;
using Gameplay.Elements;
using Services;
using UnityEngine;

namespace GameInput
{
    public class StandaloneInputManager : IUpdatable, IOnEnableAware, IStandaloneInputManager
    {
        #region Methods

        public void Move()
        {
            var horizontal = Input.GetAxis("Horizontal");
            GameplayElements.Instance.Cannon.SetRotationForce(horizontal);
        }

        public void Fire()
        {
            GameplayElements.Instance.Cannon.Fire();
        }

        public void Update()
        {
            if (Input.GetAxis("Horizontal") != 0) Move();
            var isFireRequested = Input.GetKeyDown(KeyCode.Space);
            if (isFireRequested) Fire();
        }

        public void Enable()
        {
        }

        #endregion
    }
}