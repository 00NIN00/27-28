using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemySystem
{
    public class Example : MonoBehaviour
    {
        private EnemyStorage _storage;
        private EnemyDestroyer _destroyer;

        public void Initialize(EnemyStorage storage, EnemyDestroyer destroyer)
        {
            _storage = storage;
            _destroyer = destroyer;
        }

        private void Update()
        {
            Debug.Log(_storage.EnemiesCount);

            _destroyer.Update();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                CreateEnemyWithCondition(IsDeadCondition);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                CreateEnemyWithCondition(TimeExpired(5));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                CreateEnemyWithCondition(MoreThanLimit(_storage, 10));
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CreateEnemyWithCondition(CombineOr(IsDeadCondition, TimeExpired(2)));
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                CreateEnemyWithCondition(CombineAnd(IsDeadCondition, MoreThanLimit(_storage, 3)));
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                KillRandomEnemy();
            }
        }

        private void KillRandomEnemy()
        {
            List<Enemy> enemies = new();

            var allEnemies = _storage.GetAllEnemies();

            foreach (var enemyData in allEnemies)
            {
                enemies.Add(enemyData.Enemy);
            }

            if (enemies.Count == 0)
            {
                Debug.Log("No enemies to kill!");
                return;
            }

            Enemy randomEnemy = enemies[Random.Range(0, enemies.Count)];
            randomEnemy.Kill();
        }

        private void CreateEnemyWithCondition(DestructionCondition condition)
        {
            var enemy = new Enemy();

            _storage.Add(enemy, condition);
        }

        public bool IsDeadCondition(Enemy enemy)
        {
            return !enemy.IsAlive;
        }

        public DestructionCondition TimeExpired(float lifetimeSeconds)
        {
            return (enemy) =>
            {
                float aliveTime = Time.time - enemy.CreationTime;
                return aliveTime >= lifetimeSeconds;
            };
        }

        public DestructionCondition MoreThanLimit(EnemyStorage storage, int limit)
        {
            return (enemy) =>
            {
                return storage.EnemiesCount > limit;
            };
        }
        
        public DestructionCondition CombineOr(params DestructionCondition[] conditions)
        {
            return (enemy) =>
            {
                foreach (var condition in conditions)
                {
                    if (condition(enemy))
                        return true;
                }
                
                return false;
            };
        }
        
        public static DestructionCondition CombineAnd(params DestructionCondition[] conditions)
        {
            return (enemy) =>
            {
                foreach (var condition in conditions)
                {
                    if (!condition(enemy))
                        return false;
                }
                return true;
            };
        }
    }
}