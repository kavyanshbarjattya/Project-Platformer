using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed , _jumpForce;
    [SerializeField] float _detectionRange;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] SpriteRenderer _playerSprite;
    [SerializeField] Animator _playerAnim;
    [SerializeField] Timer _timer;

    public bool flipX;

    [HideInInspector] public float _currentSpeed;

    private void Awake()
    {
        _playerAnim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _currentSpeed = 0;
        _timer.timerIsRunning = false;
    }
    private void Update()
    {
        if (_playerSprite != null)
        {

            if (flipX)
            {
                _playerSprite.flipX = true;
            }
            else
            {
                _playerSprite.flipX = false;
            }
        }

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
            flipX = false;
            _playerAnim.SetBool("isMove", true);
            _timer.timerIsRunning = true;
        }
        else if (InputManager._instance.MoveInput.x < 0)
        {
            _currentSpeed = _playerSpeed * InputManager._instance.MoveInput.x;
            flipX = true;
            if (_playerAnim != null)
            {
                _playerAnim.SetBool("isMove", true);
            }
            _timer.timerIsRunning = true;
        }
        Vector3 pos = transform.position;
        pos.x += _currentSpeed * Time.deltaTime;
        transform.position = pos;
        
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
        _playerAnim.SetTrigger("Jump");
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
