using UnityEngine;

namespace EnemySystem
{
    public class Enemy
    {
        private bool _isAlive = true;
        private float _creationTime;
        
        public bool IsAlive => _isAlive;

        public float CreationTime => _creationTime;

        public Enemy()
        {
            _creationTime = Time.time;
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
