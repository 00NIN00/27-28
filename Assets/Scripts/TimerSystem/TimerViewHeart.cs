using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace TimerSystem
{
    public class TimerViewHeart : MonoBehaviour
    {
        private Timer _timer;
        private readonly List<Image> _hearts = new();
        
        [SerializeField] private Transform _parentContainer;
        [SerializeField] private Image _heartPrefab;
        
        public void Initialize(Timer timer)
        {
            _timer = timer;
            
            _timer.Started += OnStart;
            _timer.Updated += OnUpdate;
        }

        private void OnStart()
        {
            Cleaning();
            CreateHearts();
        }

        private void OnUpdate(float currentSecond)
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                if (i <= _timer.RemainingTime) 
                    EnableHeart(_hearts[i]);
                else
                    DisableHeart(_hearts[i]);
            }
        }

        private void CreateHearts()
        {
            int heartCount = Mathf.CeilToInt(_timer.TargetTime);
            
            for (int i = 0; i < heartCount; i++)
            {
                Image heartImage = Instantiate(_heartPrefab, _parentContainer);
                _hearts.Add(heartImage);
            }
            
            foreach (Image heart in _hearts)
                EnableHeart(heart);
        }

        private void EnableHeart(Image image) => image.color = Color.red;
        private void DisableHeart(Image image) => image.color = Color.gray;
        
        private void Cleaning()
        {
            foreach (Image heart in _hearts)
                Destroy(heart.gameObject);
            
            _hearts.Clear();
        }

        private void OnDisable()
        {
            _timer.Started -= OnStart;
            _timer.Updated -= OnUpdate;
        }
    }
}