using UnityEngine;

namespace TimerSystem
{
    public class Example : MonoBehaviour
    {
        private Timer _timer;

        public void Initialize(Timer timer)
        {
            _timer = timer;

            _timer.Started += OnStart;
            _timer.Updated += OnUpdate;
            _timer.Ended += OnEnd;
            _timer.Paused += OnPause;
            _timer.UnPaused += OnUnPause;
            _timer.Stopped += OnStop;
            _timer.Restarted += OnRestart;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                _timer.Start(10);
            
            if (Input.GetKeyDown(KeyCode.R))
                _timer.Restart();
            
            if (Input.GetKeyDown(KeyCode.W))
                _timer.Stop();
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_timer.IsPausing)
                    _timer.UnPause();
                else
                    _timer.Pause();
            }
        }

        private void OnStart() => Debug.LogWarning("Start");

        private void OnUpdate(float time) => Debug.Log(time);

        private void OnEnd() => Debug.LogWarning("End");

        private void OnPause() => Debug.LogWarning("Pause");

        private void OnUnPause() => Debug.LogWarning("UnPause");

        private void OnRestart() => Debug.LogWarning("Restart");

        private void OnStop() => Debug.LogWarning("Stop");

        private void OnDisable()
        {
            _timer.Started -= OnStart;
            _timer.Updated -= OnUpdate;
            _timer.Ended -= OnEnd;
            _timer.Paused -= OnPause;
            _timer.UnPaused -= OnUnPause;
            _timer.Stopped -= OnStop;
            _timer.Restarted -= OnRestart;
        }
    }
}