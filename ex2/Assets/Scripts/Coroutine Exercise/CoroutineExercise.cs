using System;
using System.Collections;
using Services;
using UnityEngine;

namespace DefaultNamespace.Coroutine_Exercise
{
    public class CoroutineExercise : MonoBehaviour
    {
        #region Methods

        private void Start()
        {
            GameplayServices.CoroutineService.RunCoroutine((DummyCoroutine(OnStart, OnProgress, OnEnd)));
        }

        private void OnStart()
        {
            Debug.Log("Coroutine started");
        }

        private void OnProgress(int progress)
        {
            Debug.Log("Coroutine progress = " + progress);
        }

        private void OnEnd()
        {
            Debug.Log("Coroutine Ended");
        }

        private IEnumerator DummyCoroutine(Action onStart, Action<int> onProgress, Action onEnd)
        {
            var progress = 0;
            onStart?.Invoke();
            while (true)
            {
                yield return new WaitForSeconds(1);
                onProgress?.Invoke(++progress);
            }

            onEnd?.Invoke();
        }

        #endregion
    }
}