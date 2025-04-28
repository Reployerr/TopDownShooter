using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int initialPoolSize = 10;

    private Dictionary<EnemyType, Queue<GameObject>> _pool = new();

    private void Awake()
    {
        foreach (EnemyType type in System.Enum.GetValues(typeof(EnemyType)))
        {
            _pool[type] = new Queue<GameObject>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject enemy = Instantiate(GetEnemyPrefab(type));
                enemy.SetActive(false);
                _pool[type].Enqueue(enemy);
            }
        }
    }

    public GameObject GetEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemy;

        if (_pool[type].Count > 0)
        {
            enemy = _pool[type].Dequeue();
        }
        else
        {
            enemy = Instantiate(GetEnemyPrefab(type));
        }

        enemy.transform.position = position;
        enemy.transform.rotation = Quaternion.identity;
        enemy.SetActive(true);

        // Сброс состояния врага
        if (enemy.TryGetComponent<Enemy>(out var enemyComponent))
        {
            enemyComponent.ResetEnemy();
        }

        return enemy;
    }

    public void ReturnToPool(EnemyType type, GameObject enemy)
    {
        enemy.SetActive(false);
        _pool[type].Enqueue(enemy);
    }

    private GameObject GetEnemyPrefab(EnemyType type)
    {
        return type switch
        {
            EnemyType.Basic => enemyPrefabs[0],
            EnemyType.Strong => enemyPrefabs[1],
            EnemyType.Fast => enemyPrefabs[2],
            _ => enemyPrefabs[0],
        };
    }
}
