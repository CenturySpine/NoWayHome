using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.scripts
{
    public static class GameStateManager
    {
        private static DateTime _lastFire;
        private static readonly List<GameObject> EnemiesInstance;

        public static int EnemySpawnInterval = 500;


        static GameStateManager()
        {
            _lastFire = DateTime.Now;
            _lastEnemy = DateTime.Now;
            EnemiesInstance = new List<GameObject>();
        }

        private static bool AnyEnemies => EnemiesInstance.Any();
        public static Vector2 CurrentPlayerPosition { get; set; }

        public static void AddEnemy(GameObject gameObject)
        {
            EnemiesInstance.Add(gameObject);
        }

        public static void RemoveEnemy(GameObject gameObject)
        {
            EnemiesInstance.Remove(gameObject);
            TargetedObjects.Remove(gameObject);
        }

        private static readonly List<GameObject> TargetedObjects = new List<GameObject>();
        private static DateTime _lastEnemy;

        public static Vector3 GetNext()
        {
            GameObject selectedObject = null;

            if (EnemiesInstance.Count > TargetedObjects.Count)
            {
                // while (selectedobject == null)
                // {
                //     var enemyTargetr = Random.Range(0, EnemiesInstance.Count-TargetedObjects.Count);
                var currentTarget = EnemiesInstance.Except(TargetedObjects).First();
                if (!TargetedObjects.Contains(currentTarget))
                {
                    selectedObject = currentTarget;
                    TargetedObjects.Add(selectedObject);
                }
                // }
            }

            if (selectedObject != null)
            {
                return selectedObject.transform.position;
            }
            return Vector3.zero;
        }

        public static bool ShouldFire()
        {
            var diffInSeconds = (DateTime.Now - _lastFire).TotalMilliseconds;

            if (diffInSeconds < 500 || !AnyEnemies) return false;

            _lastFire = DateTime.Now;

            return true;
        }

        public static bool ShouldSpawnEnemy()
        {
            var diffInSeconds = (DateTime.Now - _lastFire).TotalMilliseconds;

            if (diffInSeconds < EnemySpawnInterval) return false;

            _lastEnemy = DateTime.Now;

            return true;
        }
    }
}