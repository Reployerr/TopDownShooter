using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private EnemyMovement _movement;
    private EnemyHealth _health;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
        _health = GetComponent<EnemyHealth>();

    }

   /* private void Update()
    {
        if (_health.Health <= 0)
        {
            Destroy(gameObject);
        }
    }*/

}
