using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private void Awake()
    {
        Health = 50f;
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
