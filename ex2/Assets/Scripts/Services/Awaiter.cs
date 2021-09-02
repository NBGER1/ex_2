using System;

namespace Services
{
    public class Awaiter
    {
        private Action _onStartCallback;
        private Action<int> _onProgressCallback;
        private Action _onEndCallback;

        public Awaiter OnStart(Action onStartCallback)
        {
            _onStartCallback = onStartCallback;
            return this;
        }

        public Awaiter OnProgress(Action<int> onProgressCallback)
        {
            _onProgressCallback = onProgressCallback;
            return this;
        }

        public Awaiter OnEnd(Action onEndCallback)
        {
            _onEndCallback = onEndCallback;
            return this;
        }

        public void Start()
        {
            _onStartCallback?.Invoke();
        }

        public void End()
        {
            _onEndCallback?.Invoke();
        }

        public void Progress(int progress)
        {
            _onProgressCallback?.Invoke(progress);
        }
    }
}