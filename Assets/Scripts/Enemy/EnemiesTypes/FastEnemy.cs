using UnityEngine;
using UnityEngine.AI;

public class FastEnemy : Enemy
{

    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private EnemyType enemyType = EnemyType.Basic;

    private NavMeshAgent _agent;
    private Collider _collider;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
    }

    public override void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        // Отключаем логику врага, чтобы он "замер"
        _agent.enabled = false;
        _collider.enabled = false;

        enemyPool.ReturnToPool(enemyType, gameObject);
    }

    public override void ResetEnemy()
    {
        Health = 50f;
        Speed = 3f;

        if (_agent != null)
        {
            _agent.enabled = true;
            _agent.speed = Speed;
        }

        if (_collider != null)
            _collider.enabled = true;
    }

    private void OnEnable()
    {
        ResetEnemy(); 
    }
}
