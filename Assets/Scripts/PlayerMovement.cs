using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _playerSpeed , _jumpForce;
    float _currentSpeed;


    private void Start()
    {
        _currentSpeed = 0;
    }

    private void Update()
    {
        Move();
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
}
