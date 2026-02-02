using System.Collections.Generic;

namespace EnemySystem
{
    public class EnemyStorage
    {
        private readonly List<EnemyData> _enemies = new();

        public int EnemiesCount => _enemies.Count;

        public void Add(Enemy enemy, DestructionCondition destructionCondition)
        {
            EnemyData data = new EnemyData(enemy, destructionCondition);
            
            _enemies.Add(data);
        }
        
        public void Remove(EnemyData enemyData)
        {
            _enemies.Remove(enemyData);
        }
        
        public IReadOnlyList<EnemyData> GetAllEnemies()
        {
            return _enemies;
        }

        public void Clear()
        {
            _enemies.Clear();
        }
    }
}