using UnityEngine;

namespace EnemySystem
{
    public class EnemyData
    {
        private Enemy _enemy;
        private DestructionCondition _destructionCondition;

        public Enemy Enemy => _enemy;
        
        public EnemyData(Enemy enemy, DestructionCondition destructionCondition)
        {
            _enemy = enemy;
            _destructionCondition = destructionCondition;
        }
        
        public bool ShouldBeDestroyed()
        {
            return _destructionCondition(_enemy);
        }

        public void Destroy()
        {
            _enemy.Destroy();
            Debug.LogWarning("Destroyed Data");
        }
    }
}