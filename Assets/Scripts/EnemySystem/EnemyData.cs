using System;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyData
    {
        private readonly Enemy _enemy;
        private readonly Func<Enemy, bool> _destructionCondition;

        public Enemy Enemy => _enemy;
        
        public EnemyData(Enemy enemy, Func<Enemy, bool> destructionCondition)
        {
            _enemy = enemy;
            _destructionCondition = destructionCondition;
        }
        public bool ShouldBeDestroyed() => _destructionCondition(_enemy);

        public void Destroy()
        {
            _enemy.Destroy();
            Debug.LogWarning("Destroyed Data");
        }
    }
}