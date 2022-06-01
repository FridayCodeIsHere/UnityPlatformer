using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 0f;
        [SerializeField] private float _jumpForce = 0f;
        [SerializeField] private GroundDetector _groundDetector;

        private SpriteRenderer _sprite;
        private UserInput _input;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        private float _multiplierSpeed = 50f;
        private float _direction;

        private static readonly int _isRunning = Animator.StringToHash("IsRunning");


        #region MonoBehaviour
        private void OnValidate()
        {
            if (_moveSpeed < 0f) _moveSpeed = 0f;
            if (_jumpForce < 0f) _jumpForce = 0f;
        }
        #endregion

        private void Awake()
        {
            _input = new UserInput();
            _input.Player.Jump.performed += context => Jump();
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _sprite = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _direction = _input.Player.Move.ReadValue<float>();

            if (_direction > 0)
            {
                _sprite.flipX = false;
            }
            else if (_direction < 0)
            {
                _sprite.flipX = true;
            }

            _animator.SetBool(_isRunning, _direction != 0f);

        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction * _multiplierSpeed * _moveSpeed * Time.fixedDeltaTime, _rigidbody.velocity.y);
        }

        private void Jump()
        {
            if (_groundDetector.IsGround)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce * 100f);
            }
        }
    }
}
