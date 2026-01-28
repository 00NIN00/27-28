using System;
using UnityEngine;
using UnityEngine.UI;

namespace TimerSystem
{
    public class TimerViewSlider : MonoBehaviour, ITimerView
    {
        private Timer _timer;
        
        [SerializeField] private Image _image;


        public void Initialize(Timer timer)
        {
            _timer = timer;

            _timer.Started += OnStart;
            _timer.Updated += OnUpdate;
        }

        private void OnStart()
        {
            _image.fillAmount = 0;
        }

        private void OnUpdate(float currentTime)
        {
            _image.fillAmount = currentTime / _timer.TargetTime;
        }

        private void OnDisable()
        {
            _timer.Started -= OnStart;
            _timer.Updated -= OnUpdate;
        }
    }

    public interface ITimerView
    {
    }
}
