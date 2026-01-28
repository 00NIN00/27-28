using UnityEngine;

namespace TimerSystem
{
    public class Example : MonoBehaviour
    {
        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer(this);

            _timer.Started += OnStart;
            _timer.Updated += OnUpdate;
            _timer.Ended += OnEnd;
            _timer.Paused += OnPause;
            _timer.UnPaused += OnUnPause;
            _timer.Stopped += OnStop;
            _timer.Restarted += OnRestart;
            
            Debug.LogWarning("_timer" + _timer.CanStart());
        }

        private void Update()
        {
            //Debug.Log($"{_timer.CurrentTime}/{_timer.TargetTime}");


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_timer.IsPausing)
                    _timer.UnPause();
                else
                    _timer.Pause();
            }
            
            if (Input.GetKeyDown(KeyCode.R))
                _timer.Restart();
            
            if (Input.GetKeyDown(KeyCode.S))
                _timer.Start(10);
            
            if (Input.GetKeyDown(KeyCode.W))
                _timer.Stop();
        }

        private void OnStart()
        {
            Debug.LogWarning("Start");
        }

        private void OnUpdate(float time)
        {
            Debug.Log(time);
        }

        private void OnEnd()
        {
            Debug.LogWarning("End");
        }

        private void OnPause()
        {
            Debug.LogWarning("Pause");
        }

        private void OnUnPause()
        {
            Debug.LogWarning("UnPause");
        }

        private void OnRestart()
        {
            Debug.LogWarning("Restart");
        }

        private void OnStop()
        {
            Debug.LogWarning("Stop");
        }
        
        private void OnDisable()
        {
            _timer.Started -= OnStart;
            _timer.Updated -= OnUpdate;
            _timer.Ended -= OnEnd;
            _timer.Paused -= OnPause;
            _timer.UnPaused -= OnUnPause;
            _timer.Stopped-= OnStop;
            _timer.Restarted -= OnRestart;
        }

    }
}