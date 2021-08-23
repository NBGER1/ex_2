using UnityEngine;

namespace Particles
{
    [RequireComponent(typeof(ParticleSystem))]
    public class PlayParticlesOnEnable : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private ParticleSystem _ps;

        #endregion

        #region Methods

        private void OnEnable()
        {
            _ps.Play(true);
        }

        #endregion
    }
}