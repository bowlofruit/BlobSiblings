using UnityEngine;
using UnityEngine.Events;

public class MoveController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _groundJump;

    public UnityEvent<int> OnChangeMoveDirection { get; set; } = new UnityEvent<int>();
        
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
        _playerRB = GetComponent<Rigidbody2D>();
        _playerRB.freezeRotation = true;

        _jumpCommand = new JumpCommand(_playerRB, _jumpForse);
        _moveCommand = new MoveCommand(_playerRB, _speedMove);

        GetComponentInChildren<GroundDetect>().OnGroundCheck?.AddListener(UpdateGroundStatus);
    }

    private void Update()
    {
        JumpInput();
        FasterFall();

        OnChangeMoveDirection?.Invoke(GetMoveDirection());
        _moveCommand.SetDirection(GetMoveDirection());
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
        return Input.GetKey(_leftMoveKey) ? -1 : Input.GetKey(_rightMoveKey) ? 1 : 0;
    }

    private void FasterFall()
    {
        _playerRB.gravityScale = _playerRB.velocity.y < 0 ? _fallingGravityScale : _gravityScale;
    }

    private void JumpInput()
    {
        if (Input.GetKey(_jumpKey))
        {
            _isJumping = true;
        }
    }

    private void UpdateGroundStatus(bool isGrounded)
    {
        _isGround = isGrounded;
    }
}