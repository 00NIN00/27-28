using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace TimerSystem
{
    public class TimerViewHeart : MonoBehaviour
    {
        private Timer _timer;
        
        [SerializeField] private Transform _container;
        [SerializeField] private Image _heartPrefab;
        private readonly List<Image> _hearts = new();
        
        public void Initialize(Timer timer)
        {
            _timer = timer;
            
            _timer.Started += OnStart;
            _timer.SecondUpdated += OnUpdate;
        }

        private void OnStart()
        {
            Cleaning();
            CreateHearts();
        }

        private void OnUpdate(int currentSecond)
        {
            /*for (int i = _hearts.Count-1; i >= 0; i--)
            {
                if (_timer.TargetTime - currentSecond - 1 >= i)
                {
                    _hearts[i].color = Color.red;
                }
                else
                {
                    _hearts[i].color = Color.grey;
                }
            }*/
            
            for (int i = 0; i < _hearts.Count; i++)
            {
                if (i <= _timer.RemainingTime) 
                {
                    _hearts[i].color = Color.red;
                }
                else
                {
                    _hearts[i].color = Color.grey;
                }
            }
        }

        private void CreateHearts()
        {
            int heartCount = Mathf.CeilToInt(_timer.TargetTime);
            
            for (int i = 0; i < heartCount; i++)
            {
                _hearts.Add(Instantiate(_heartPrefab, _container));
            }
            
            foreach (var heart in _hearts)
                heart.color = Color.red;
        }

        private void Cleaning()
        {
            foreach (var heart in _hearts)
                Destroy(heart.gameObject);
            
            _hearts.Clear();
        }

        private void OnDisable()
        {
            _timer.Started -= OnStart;
            _timer.SecondUpdated -= OnUpdate;
        }
    }
}