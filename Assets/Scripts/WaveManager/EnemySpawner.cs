using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private EnemyPool enemyPool;

    public void SpawnEnemies(int waveNumber, int numberOfEnemies)
    {
        EnemyType[] enemyTypes = GetEnemyTypesForWave(waveNumber);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            EnemyType type = enemyTypes[Random.Range(0, enemyTypes.Length)];
            enemyPool.GetEnemy(type, spawnPoint.position);
        }
    }

    private EnemyType[] GetEnemyTypesForWave(int waveNumber)
    {
        if (waveNumber >= 3)
        {
            return new[] { EnemyType.Basic, EnemyType.Strong, EnemyType.Fast };
        }
        return new[] { EnemyType.Basic };
    }
}