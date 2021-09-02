using System;
using System.Collections;
using Services;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace.Coroutine_Exercise
{
    public class WaitService : IWaitService
    {
        public IAwaiter WaitFor(float delay)
        {
            IAwaiter awaiter = new Awaiter();
            GameplayServices.CoroutineService.RunCoroutine(WaitForInternal(delay, awaiter));
            return awaiter;
        }

        public void WaitFor(float delay, Action callback)
        {
            GameplayServices.CoroutineService.RunCoroutine((WaitForInternal(delay, callback)));
        }

        private IEnumerator WaitForInternal(float delaySeconds, IAwaiter awaiter)
        {
            yield return null;
            awaiter.Start();
            delaySeconds = Mathf.Abs(delaySeconds);
            var timeIteration = delaySeconds % 1 > 0 ? delaySeconds % 1 : 1;
            for (var i = 0; i < delaySeconds; i++)
            {
                awaiter.Progress(i);
                yield return new WaitForSeconds(timeIteration);
            }

            awaiter.End();
        }

        private IEnumerator WaitForInternal(float delaySeconds, Action callback)
        {
            yield return null;
            delaySeconds = Mathf.Abs(delaySeconds);
            var timeIteration = delaySeconds % 1 > 0 ? delaySeconds % 1 : 1;
            for (var i = 0; i < delaySeconds; i++)
            {
                yield return new WaitForSeconds(timeIteration);
            }

            callback?.Invoke();
        }
    }
}