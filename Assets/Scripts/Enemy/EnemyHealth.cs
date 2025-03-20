using UnityEngine;

public class EnemyHealth : Enemy
{
    [SerializeField] private float maxHealth = 100f;

    private void Awake()
    {
        Health = maxHealth;
        Speed = 3f;
    }

    public override void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
