using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        _playerMover.Move(direction, speed);
    }
}
