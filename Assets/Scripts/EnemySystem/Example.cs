using System;
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
                CreateEnemyWithCondition(IsDeadCondition);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                CreateEnemyWithCondition(enemy => TimeExpired(5, enemy));

            if (Input.GetKeyDown(KeyCode.Alpha3))
                CreateEnemyWithCondition(MoreThanLimit(_storage, 2));

            if (Input.GetKeyDown(KeyCode.Alpha4))
                CreateEnemyWithCondition(CombineOr(IsDeadCondition, enemy => TimeExpired(5, enemy)));

            if (Input.GetKeyDown(KeyCode.Alpha5))
                CreateEnemyWithCondition(CombineAnd(IsDeadCondition, MoreThanLimit(_storage, 3)));

            if (Input.GetKeyDown(KeyCode.K))
                KillRandomEnemy();

            if (Input.GetKeyDown(KeyCode.C))
                _storage.Clear();
        }

        private void KillRandomEnemy()
        {
            IReadOnlyList<EnemyData> allEnemies = _storage.GetAllEnemies();

            if (allEnemies.Count == 0)
                return;

            Enemy randomEnemy = allEnemies[Random.Range(0, allEnemies.Count)].Enemy;
            randomEnemy.Kill();
        }

        private void CreateEnemyWithCondition(Func<Enemy, bool> condition)
        {
            Enemy enemy = new Enemy();

            _storage.Add(enemy, condition);
        }

        private bool IsDeadCondition(Enemy enemy)
        {
            return !enemy.IsAlive;
        }

        private bool TimeExpired(float lifetimeSeconds, Enemy enemy)
            => Time.time - enemy.CreationTime >= lifetimeSeconds;
        
        /*
        private Func<Enemy, bool> TimeExpired(float lifetimeSeconds)
            => enemy => Time.time - enemy.CreationTime >= lifetimeSeconds;
*/

        private Func<Enemy, bool> MoreThanLimit(EnemyStorage storage, int limit)
            => enemy => storage.EnemiesCount > limit;

        private Func<Enemy, bool> CombineOr(params Func<Enemy, bool>[] conditions)
        {
            return enemy =>
            {
                foreach (var condition in conditions)
                {
                    if (condition(enemy))
                        return true;
                }

                return false;
            };
        }

        private static Func<Enemy, bool> CombineAnd(params Func<Enemy, bool>[] conditions)
        {
            return enemy =>
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