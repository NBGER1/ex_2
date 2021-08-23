using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class UnityCore : MonoBehaviour, IUnityCoreService, ICoroutineService
    {
        #region Fields

        private readonly IList<IUpdatable> _updatables
            = new List<IUpdatable>();

        private readonly IList<IOnEnableAware> _onEnableAwares
            = new List<IOnEnableAware>();

        #endregion

        #region Methods

        private void Update()
        {
            for (var i = 0; i < _updatables.Count; i++)
            {
                _updatables[i].Update();
            }
        }

        private void OnEnable()
        {
            for (var i = 0; i < _onEnableAwares.Count; i++)
            {
                _onEnableAwares[i].Enable();
            }
        }

        public void RegisterUpdatable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void RegisterOnEnableAware(IOnEnableAware onEnableAware)
        {
            _onEnableAwares.Add(onEnableAware);
        }

        public Coroutine RunCoroutine(IEnumerator coroutineBody)
        {
            return StartCoroutine(coroutineBody);
        }

        public void EndCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        public void WaitFor(float delaySeconds, Action endCallback)
        {
            RunCoroutine(WaitForInternal(delaySeconds, endCallback));
        }

        private IEnumerator WaitForInternal(float delaySeconds, Action endcallback)
        {
            yield return new WaitForSeconds(delaySeconds);
            endcallback?.Invoke();
        }

        #endregion
    }
}