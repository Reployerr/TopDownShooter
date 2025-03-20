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
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = firePoint.position.y;

            Vector3 direction = (targetPosition - firePoint.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.GetComponent<Bullet>().Initialize(_stats.Damage, _stats.BulletRange);
        }
    }

}
