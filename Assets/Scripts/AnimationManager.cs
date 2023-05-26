using Unity.VisualScripting;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool IsGround { get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponentInChildren<GroundDetect>().OnGroundCheck?.AddListener(UpdateGroundStatus);
        GetComponent<MoveController>().OnChangeMoveDirection?.AddListener(UpdateMoveAnimation);
    }

    private void Update()
    {
        UpdateJumpAnimation();
    }

    private void UpdateMoveAnimation(int direction)
    {
        _animator.SetFloat("MoveDirection", Mathf.Abs(direction));
        _spriteRenderer.flipX = direction < 0;
    }

    private void UpdateJumpAnimation()
    {
        _animator.SetBool("IsGrounded", IsGround);
    }

    private void UpdateGroundStatus(bool isGrounded)
    {
        IsGround = isGrounded;
    }
}