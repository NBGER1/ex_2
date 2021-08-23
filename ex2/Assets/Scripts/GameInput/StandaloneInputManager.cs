using Core;
using DefaultNamespace.Gameplay;
using Gameplay.Elements;
using Services;
using UnityEngine;

namespace GameInput
{
    public class StandaloneInputManager : IUpdatable, IOnEnableAware
    {
        #region Methods

        public void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            GameplayElements.Instance.Cannon.SetRotationForce(horizontal);

            var isFireRequested = Input.GetAxisRaw("Fire1") > 0;
            if (isFireRequested)
            {
                GameplayElements.Instance.Cannon.Fire();
            }
        }

        public void Enable()
        {
        }

        #endregion
    }
}