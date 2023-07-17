using UnityEngine;

namespace BlobSiblings
{
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private bool _isGround;
        private int _direction;
        private bool _isPush;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            GetComponentInChildren<GroundDetect>().GroundCheckEvent?.AddListener(UpdateGroundStatus);
            GetComponent<MoveController>().ChangeMoveDirectionEvent?.AddListener(UpdateDirectionStatus);
            GetComponentInChildren<PushDetector>().PushCheckEvent?.AddListener(UpdatePushStatus);
            GetComponent<EventController>().DieStatusChangedEvent?.AddListener(UpdateDieStatus);
        }

        private void Update()
        {
            UpdateMoveAnimation();
            UpdateJumpAnimation();
            UpdatePushAnimation();
        }

        private void UpdateMoveAnimation()
        {
            _animator.SetFloat("MoveDirection", Mathf.Abs(_direction));
            _spriteRenderer.flipX = _direction < 0;
        }

        private void UpdateJumpAnimation()
        {
            _animator.SetBool("IsGround", _isGround);
        }

        private void UpdatePushAnimation()
        {
            _animator.SetBool("IsPush", Mathf.Abs(_direction) > 0 && _isPush);
            _spriteRenderer.flipX = _direction < 0;
        }

        private void UpdateGroundStatus(bool isGrounded)
        {
            _isGround = isGrounded;
        }

        private void UpdateDirectionStatus(int direction)
        {
            _direction = direction;
        }

        private void UpdateDieStatus(bool isDie)
        {
            _animator.SetBool("IsDie", isDie);
        }

        private void UpdatePushStatus(bool isPush)
        {
            _isPush = isPush;
        }
    }
}