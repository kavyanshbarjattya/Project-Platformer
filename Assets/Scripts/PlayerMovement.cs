using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed , _jumpForce;
    [SerializeField] float _detectionRange;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;
    [SerializeField] Rigidbody2D _rb;

    float _currentSpeed;

    private void Start()
    {
        _currentSpeed = 0;
    }

    private void FixedUpdate()
    {
        Move();

        if (InputManager._instance.JumpInput && RaycastDetection())
        {
            Jump();
        }
    }


    void Move()
    {
        if (InputManager._instance.MoveInput.x > 0)
        {
            _currentSpeed = _playerSpeed * InputManager._instance.MoveInput.x;
        }
        else if (InputManager._instance.MoveInput.x < 0)
        {
            _currentSpeed = _playerSpeed * InputManager._instance.MoveInput.x;
        }
        transform.position += new Vector3(_currentSpeed * Time.deltaTime, transform.position.y, 0);
    }

    bool RaycastDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _detectionRange, _groundLayer);
        return hit.collider != null;
    }

    void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0f);
        _rb.AddForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_groundCheck.position , _groundCheck.position + Vector3.down * _detectionRange);
        }
    }


}
