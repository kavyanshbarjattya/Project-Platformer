using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Input Action Asset")]
    [SerializeField] InputActionAsset _inputActionAsset;

    [Header("Input Action Map")]
    [SerializeField] string _actionMap = "Player";

    [Header("Input Actions")]
    [SerializeField] string _move = "Horizontal";
    [SerializeField] string _jump = "Jump";

    private InputAction _moveAction;
    private InputAction _jumpAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpInput { get; private set; }

    public static InputManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance);
        }

        _moveAction = _inputActionAsset.FindActionMap(_actionMap).FindAction(_move);
        _jumpAction = _inputActionAsset.FindActionMap(_actionMap).FindAction(_jump);

        RegisterInputs();
    }

    void RegisterInputs()
    {
        _moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        _moveAction.canceled += context => MoveInput = Vector2.zero;

        _jumpAction.performed += context => JumpInput = true;
        _jumpAction.canceled += context => JumpInput = false;
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _jumpAction.Enable();
    }
    private void OnDisable()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
    }
}
