using System;

namespace Services
{
    public class Awaiter : IAwaiter
    {
        #region Fields

        private Action _onStartCallback;
        private Action<float> _onProgressCallback;
        private Action _onEndCallback;

        #endregion

        #region Methods

        public Awaiter OnStart(Action onStartCallback)
        {
            _onStartCallback = onStartCallback;
            return this;
        }

        public Awaiter OnProgress(Action<float> onProgressCallback)
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

        public void Progress(float progress)
        {
            _onProgressCallback?.Invoke(progress);
        }

        #endregion
    }
}