using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float waveInterval = 5f;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private int enemiesPerWave = 5;

    private float _timer;
    private int _waveNumber = 1;

    private void Start()
    {
        _timer = waveInterval;
        enemySpawner.SpawnEnemies(_waveNumber, enemiesPerWave); 
        _waveNumber++;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            StartWave();
            _timer = waveInterval;
        }
    }

    private void StartWave()
    {
        enemiesPerWave += _waveNumber; 
        enemySpawner.SpawnEnemies(_waveNumber, enemiesPerWave);
        _waveNumber++;
    }
}