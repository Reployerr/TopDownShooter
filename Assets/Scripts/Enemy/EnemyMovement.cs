using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_target != null)
        {
            _agent.SetDestination(_target.position); 
        }
    }
}
