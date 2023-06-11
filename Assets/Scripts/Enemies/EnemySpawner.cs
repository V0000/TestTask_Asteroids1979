using System.Collections.Generic;
using Enemies.Movement;
using UI;
using UnityEngine;

namespace Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform player; 
        [SerializeField] private List<EnemySpawnData> dataList;
        [SerializeField] private UIController uiController;
        private Camera _mainCamera;
        private const float SpawnOffset = 1f;
        private float _minY;
        private float _maxY;
        private float _minX;
        private float _maxX;
        private float _z;
        

        [System.Serializable]
        public class EnemySpawnData
        {
            public GameObject enemyPrefab;
            public float spawnInterval;
            [HideInInspector] public float timer;
        }
        private void Start()
        {
            _mainCamera = Camera.main;
            CalculateScreenBounds();

        }

        private void Update()
        {
            foreach (EnemySpawnData enemy in dataList)
            {
                enemy.timer += Time.deltaTime;
                if (enemy.timer > enemy.spawnInterval)
                {
                    enemy.timer = 0;
                    SpawnEnemy(enemy.enemyPrefab);

                }
            }
        }
        private void SpawnEnemy(GameObject enemyPrefab)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);
            enemy.GetComponent<EnemyMovement>().Target = player;
        }
        
        private Vector3 GetRandomSpawnPosition()
        {
            float spawnX;
            float spawnY;
            
            var side = Random.Range(0, 4);
            switch (side)
            {
                case 0:
                    spawnX = Random.Range(_minX - SpawnOffset, _minX);
                    spawnY = Random.Range(_minY, _maxY);
                    break;
                case 1:
                    spawnX = Random.Range(_maxX, _maxX + SpawnOffset);
                    spawnY = Random.Range(_minY, _maxY);
                    break;
                case 2:
                    spawnY = Random.Range(_minY - SpawnOffset, _minY);
                    spawnX = Random.Range(_minX, _maxX);
                    break;
                case 3:
                    spawnY = Random.Range(_maxY, _maxY + SpawnOffset);
                    spawnX = Random.Range(_minX, _maxX);
                    break;
                default:
                    spawnX = Random.Range(_minX - SpawnOffset, _minX);
                    spawnY = Random.Range(_minY - SpawnOffset, _minY);
                    break;
            }
            

            return new Vector3(spawnX, spawnY, 0);
        }

        private void CalculateScreenBounds()
        {
            _minY = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
            _maxY = _mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
            _minX = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            _maxX = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            _z = _mainCamera.nearClipPlane;
        }

    }
}
