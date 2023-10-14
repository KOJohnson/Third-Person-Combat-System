using System;

namespace ThirdPersonMeleeSystem.Timers
{
    public class Timer
    {
        public event Action OnTimerComplete;

        private readonly float _timerDuration;
        private float _timeElapsed;
        public bool IsTimerComplete { get; private set; }

        public Timer(float duration)
        {
            _timerDuration = duration;
        }
        
        public void Tick(float deltaTime)
        {
            if (IsTimerComplete) return;
            
            if (_timeElapsed < _timerDuration)
            {
                _timeElapsed += deltaTime;
            }
            else
            {
                if (!IsTimerComplete)
                {
                    IsTimerComplete = true;
                    OnTimerCompleteEvent();
                }
            }
        }

        public void Reset()
        {
            IsTimerComplete = false;
            _timeElapsed = 0f;
        }

        private void OnTimerCompleteEvent()
        {
            OnTimerComplete?.Invoke();
        }
    }
}