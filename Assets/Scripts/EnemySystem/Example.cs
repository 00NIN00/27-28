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
                CreateEnemyWithCondition(MoreThanLimit(_storage, 2));
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
            IReadOnlyList<EnemyData> allEnemies = _storage.GetAllEnemies();
            
            if (allEnemies.Count == 0)
                return;

            Enemy randomEnemy = allEnemies[Random.Range(0, allEnemies.Count)].Enemy;
            randomEnemy.Kill();
        }

        private void CreateEnemyWithCondition(DestructionCondition condition)
        {
            Enemy enemy = new Enemy();

            _storage.Add(enemy, condition);
        }

        private bool IsDeadCondition(Enemy enemy)
        {
            return !enemy.IsAlive;
        }

        private DestructionCondition TimeExpired(float lifetimeSeconds)
        {
            return (enemy) =>
            {
                float aliveTime = Time.time - enemy.CreationTime;
                return aliveTime >= lifetimeSeconds;
            };
        }

        private DestructionCondition MoreThanLimit(EnemyStorage storage, int limit)
        {
            return (enemy) => storage.EnemiesCount > limit;
        }

        private DestructionCondition CombineOr(params DestructionCondition[] conditions)
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

        private static DestructionCondition CombineAnd(params DestructionCondition[] conditions)
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