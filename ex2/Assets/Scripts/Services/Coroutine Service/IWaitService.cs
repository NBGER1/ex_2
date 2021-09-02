using System;
using Services;

namespace DefaultNamespace.Coroutine_Exercise
{
    public interface IWaitService
    {
        IAwaiter WaitFor(float delay);
        void WaitFor(float delay, Action callback);
    }
}