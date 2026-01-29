namespace EnemySystem
{
    public class EnemyDestroyer
    {
        private EnemyStorage _storage;

        public EnemyDestroyer(EnemyStorage storage)
        {
            _storage = storage;
        }

        public void Update()
        {
            var enemies = _storage.GetAllEnemies();
            
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                var enemyData = enemies[i];
                
                if (enemyData.ShouldBeDestroyed())
                {
                    enemyData.Destroy();
                    _storage.Remove(enemyData);
                }
            }
        }
    }
}