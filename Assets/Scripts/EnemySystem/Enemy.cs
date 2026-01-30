using UnityEngine;

namespace EnemySystem
{
    public class Enemy
    {
        private bool _isAlive = true;
        
        public bool IsAlive => _isAlive;

        public float CreationTime { get; private set; }

        public Enemy()
        {
            CreationTime = Time.time;
        }
        
        public void Kill()
        {
            _isAlive = false;
            Debug.LogWarning("Killed");
        }

        public void Destroy()
        {
            _isAlive = false;
            Debug.LogWarning("Destroyed");
        }
    }
}
