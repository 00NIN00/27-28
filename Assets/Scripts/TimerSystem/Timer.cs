using System;
using System.Collections;
using UnityEngine;

namespace TimerSystem
{
    public class Timer
    {
        public event Action Started;
        public event Action Paused;
        public event Action UnPaused;
        public event Action Ended;
        public event Action Restarted;
        public event Action Stopped;
        public event Action<float> Updated;
        public event Action<int> SecondUpdated;

        private readonly MonoBehaviour _coroutineRunner;

        private float _pastTargetTime;
        private float _targetTime;
        private float _currentTime;
        private bool _isRunning;
        private Coroutine _coroutine;

        public bool IsWorking => _coroutine != null;
        public float TargetTime => _targetTime;
        public float CurrentTime => _currentTime;
        public float RemainingTime => _targetTime - _currentTime;
        public bool IsRunning => _isRunning;
        public bool IsPausing => !_isRunning && IsWorking;

        public Timer(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public bool CanStart() => !IsWorking;
        public bool CanStop() => IsWorking;
        
        public void Start(float time)
        {
            if (!CanStart())
                return;

            Reset();

            _targetTime = time;
            _isRunning = true;
            _coroutine = _coroutineRunner.StartCoroutine(Process());
            Started?.Invoke();
        }
        
        public void Pause()
        {
            if (!IsWorking || !_isRunning)
                return;

            Paused?.Invoke();
            _isRunning = false;
        }

        public void UnPause()
        {
            if (!IsWorking || _isRunning)
                return;

            UnPaused?.Invoke();
            _isRunning = true;
        }

        public void Restart()
        {
            if (!CanStop()) 
                return;
            
            Stop();

            if (!CanStart())
                return;
            
            Restarted?.Invoke();
            
            Start(_pastTargetTime);
        }
        
        public void Stop()
        {
            if (!CanStop())
                return;

            Stopped?.Invoke();
            _coroutineRunner.StopCoroutine(_coroutine);
            Reset();
        }

        private IEnumerator Process()
        {
            int lastSecond = 0;
            
            while (_currentTime < _targetTime)
            {
                yield return new WaitUntil(() => _isRunning);

                _currentTime += Time.deltaTime;
                Updated?.Invoke(_currentTime);
                
                int currentSecond = Mathf.FloorToInt(_currentTime);
                if (currentSecond > lastSecond)
                {
                    lastSecond = currentSecond;
                    SecondUpdated?.Invoke(currentSecond);
                }
                
                yield return null;
            }

            Complete();
        }

        private void Complete()
        {
            Ended?.Invoke();
            Reset();
        }

        private void Reset()
        {
            _pastTargetTime = _targetTime;
            _isRunning = false;
            _currentTime = 0;
            _targetTime = 0;
            _coroutine = null;
        }
    }
}