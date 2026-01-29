using UnityEngine;

namespace EnemySystem
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Example _example;
        
        private void Awake()
        {
            var storage = new EnemyStorage();
            var destroyer = new EnemyDestroyer(storage);
            
            _example.Initialize(storage, destroyer);
        }
    }
}