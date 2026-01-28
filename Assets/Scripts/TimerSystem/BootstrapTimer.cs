using UnityEngine;

namespace TimerSystem
{
    public class BootstrapTimer : MonoBehaviour
    {
        [Header("Example")]
        [SerializeField] private Example _example;

        [Header("Views")]
        [SerializeField] private TimerViewSlider _timerViewSlider;
        [SerializeField] private TimerViewHeart _timerViewHeart;
        
        private void Awake()
        {
            var timer = new Timer(this);
            
            _example.Initialize(timer);
            
            _timerViewSlider.Initialize(timer);
            _timerViewHeart.Initialize(timer);
        }
    }
}