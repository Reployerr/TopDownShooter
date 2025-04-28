using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float Damage { get; private set; } = 10f;
    public float FireRate { get; private set; } = 2f;
    public float BulletRange { get; private set; } = 60f;

    public void UpgradeDamage(float amount) => Damage += amount;
    public void UpgradeFireRate(float amount) => FireRate += amount;
    public void UpgradeBulletRange(float amount) => BulletRange += amount;
}
