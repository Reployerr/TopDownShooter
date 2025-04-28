using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private Camera _camera;
    private PlayerStats _stats;
    private float _nextFireTime;

    private void Awake()
    {
        _camera = Camera.main;
        _stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + 1f / _stats.FireRate;
        }
    }

    private void Shoot()
    {
        // Луч из курсора
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, firePoint.position);

        // Пересекаем луч с горизонтальной плоскостью на уровне игрока
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = (targetPoint - firePoint.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.GetComponent<Bullet>().Initialize(_stats.Damage, _stats.BulletRange);
        }
    }
}
