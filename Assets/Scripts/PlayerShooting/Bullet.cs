using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private float _damage;
    private float _range;
    private Vector3 _startPosition;

    public void Initialize(float damage, float range)
    {
        _damage = damage;
        _range = range;
        _startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(_startPosition, transform.position) >= _range)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(_damage);
            }
            Destroy(gameObject); 
        }
        else if (other.CompareTag("Env"))
        {
            Debug.Log("env touched");
            Destroy(gameObject);
        }
    }

}
