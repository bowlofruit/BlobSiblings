using UnityEngine;
using UnityEngine.Events;

public class MoveController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _groundJump;

    public UnityEvent<int> ChangeMoveDirectionEvent { get; set; } = new UnityEvent<int>();

    private bool _isInputAccess;
    private MoveCommand _moveCommand;
    private JumpCommand _jumpCommand;
    private Rigidbody2D _playerRB;

    [Header("Move Settings")]
    [SerializeField] private float _speedMove;

    [Header("Control Keys")]
    [SerializeField] private KeyCode _leftMoveKey;
    [SerializeField] private KeyCode _rightMoveKey;
    [SerializeField] private KeyCode _jumpKey;

    [Header("Jump Setting")]
    [SerializeField] private float _jumpForse;
    private bool _isJumping;
    private bool _isGround;

    [Header("Gravity Setting")]
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _fallingGravityScale;


    private void Awake()
    {
        EventController.SwitchInputSystemEvent.Invoke(true);

        _playerRB = GetComponent<Rigidbody2D>();
        _playerRB.freezeRotation = true;

        _isInputAccess = true;

        _jumpCommand = new JumpCommand(_playerRB, _jumpForse);
        _moveCommand = new MoveCommand(_playerRB, _speedMove);

        EventController.SwitchInputSystemEvent?.AddListener(UpdateInputAccessStatus);
        ChangeMoveDirectionEvent.AddListener(_moveCommand.SetDirection);

        GetComponentInChildren<GroundDetect>().GroundCheckEvent?.AddListener(UpdateGroundStatus);     
        GetComponentInChildren<GroundDetect>().ChangeIceAccelerationEvent?.AddListener(_moveCommand.SetIceAcceleration);
    }

    private void Update()
    {
        JumpInput();
        FasterFall();

        ChangeMoveDirectionEvent?.Invoke(GetMoveDirection());
    }

    private void FixedUpdate()
    {
        if (_isJumping && _isGround)
        {
            _groundJump.Play();
            _jumpCommand.Execute();
        }
        _isJumping = false;
        _moveCommand?.Execute();
    }

    private int GetMoveDirection()
    {
        return Input.GetKey(_leftMoveKey) && _isInputAccess ? -1 : Input.GetKey(_rightMoveKey) && _isInputAccess ? 1 : 0;
    }

    private void FasterFall()
    {
        _playerRB.gravityScale = _playerRB.velocity.y < 0 ? _fallingGravityScale : _gravityScale;
    }

    private void JumpInput()
    {
        if (Input.GetKey(_jumpKey) && _isInputAccess)
        {
            _isJumping = true;
        }
    }

    private void UpdateGroundStatus(bool isGrounded)
    {
        _isGround = isGrounded;
    }

    private void UpdateInputAccessStatus(bool isInputAccess)
    {
        _isInputAccess = isInputAccess;
    }

    public void ChangeMoveProps(float speedMove, float jumpForse)
    {
        _speedMove = speedMove;
        _jumpForse = jumpForse;
    }

    public void SaveMoveProps(out float speedMove, out float jumpForse)
    {
        speedMove = _speedMove;
        jumpForse = _jumpForse;
    }
}