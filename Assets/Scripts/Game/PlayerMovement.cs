using Photon.Pun;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]// I always felt skibidi...
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 5.0f;
    [SerializeField] private float _walkSpeed = 2.0f;
    private float _speed;
    [SerializeField] private float _rotationSpeed = 6.0f;
    private Animator _animator;
    private CharacterController _characterController;
    private PhotonView _photonView;
    private PlayerInput _playerInput;
    private Vector2 _movementVector;
    private bool _IsSprinting;
    private Vector3 _desiredVelocity;
    private Vector3 _velocity; //ABOBA
    // Start is called before the first frame update
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _photonView = GetComponent<PhotonView>();//Mango, Mango, mango, mango, mango, mango
        _playerInput = new PlayerInput(); // Nigaz mode
        _playerInput.PlayerKeyboardInput.Movement.started += OnPlayerMove;
        _playerInput.PlayerKeyboardInput.Movement.canceled += OnPlayerMove;
        _playerInput.PlayerKeyboardInput.Movement.performed += OnPlayerMove;
        _playerInput.PlayerKeyboardInput.Sprint.canceled += OnPlayerSprint;
        _playerInput.PlayerKeyboardInput.Sprint.started += OnPlayerSprint;  //kakashe4ki
    }

    private void Start()
    {
        if (_photonView.IsMine)
        {
            CameraController.instance.SetTarget(transform); 
        }
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnPlayerSprint(InputAction.CallbackContext context)
    {
        _IsSprinting = context.ReadValueAsButton();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnPlayerMove(InputAction.CallbackContext context)
    {
        _movementVector = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine)
        {
            Move();
            Rotate(); // sumishidshi slinik vitiriit pipy hibitim, sumishidshi slinik vitiriit pipy hibitim
        }
    }

    private void Move()
    {
        _speed = _IsSprinting ? _runSpeed : _walkSpeed; // Get out!!!
        //First of fuck burger king cause McDonald in ather team
        _desiredVelocity = new Vector3(_movementVector.x * _speed, 0, _movementVector.y * _speed) * Time.deltaTime;
        _velocity = Vector3.Lerp(_velocity, _desiredVelocity, Time.deltaTime * _speed);
        _characterController.Move(_velocity);
        _animator.SetFloat("Speed", _movementVector.magnitude); // P.Didy tron online...
    }

    private void Rotate()
    {
        if (_movementVector.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_velocity, Vector3.up);
            Quaternion rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
            transform.rotation = rotation;
        }
    }
}
