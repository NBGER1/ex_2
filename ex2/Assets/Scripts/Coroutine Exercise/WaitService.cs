using System;
using System.Collections;
using Services;
using UnityEngine;

namespace DefaultNamespace.Coroutine_Exercise
{
    public class WaitService : IWaitService
    {
        public Awaiter WaitFor(int delaySeconds)
        {
            var a = new Awaiter();
            GameplayServices.CoroutineService.RunCoroutine((WaitForInternal(delaySeconds, a)));
            return a;
        }

        public IEnumerator WaitForInternal(int delaySeconds, Awaiter awaiter)
        {
            yield return null;
            awaiter.Start();
            for (var i = 0; i < delaySeconds; i++)
            {
                awaiter.Progress(i);
                yield return new WaitForSeconds(delaySeconds);
            }

            awaiter.End();
        }
    }
}