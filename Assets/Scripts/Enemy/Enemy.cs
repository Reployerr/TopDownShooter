using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float Health { get; protected set; }
    public float Speed { get; protected set; }

    public abstract void TakeDamage(float amount);
    public abstract void Die();
    public abstract void ResetEnemy(); // 👈 добавим сюда
}
