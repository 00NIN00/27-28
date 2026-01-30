using System.Collections.Generic;

namespace EnemySystem
{
    public class EnemyDestroyer
    {
        private readonly EnemyStorage _storage;

        public EnemyDestroyer(EnemyStorage storage)
        {
            _storage = storage;
        }

        public void Update()
        {
            IReadOnlyList<EnemyData> enemies = _storage.GetAllEnemies();
            
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                EnemyData enemyData = enemies[i];
                
                if (enemyData.ShouldBeDestroyed())
                {
                    enemyData.Destroy();
                    _storage.Remove(enemyData);
                }
            }
        }
    }
}