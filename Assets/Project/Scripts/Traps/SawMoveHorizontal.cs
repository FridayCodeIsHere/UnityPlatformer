using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SawMoveHorizontal : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _distance;
        private Rigidbody2D _rigidbody;

        private float _multiplierSpeed = 100f;
        private float _multiplierRotate = 300f;
        private float _startPos;
        private float _endPos;
        private int _direction = 1;

        private bool _isMovingRight = true;

        #region MonoBehaviour
        private void OnValidate()
        {
            if (_speed < 0f) _speed = 0f;
            if (_distance < 0f) _distance = 0f;
        }
        #endregion

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _startPos = transform.position.x;
            _endPos = _startPos + _distance;
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * _speed * _direction * _multiplierRotate * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (CheckBoundaries())
            {
                _rigidbody.velocity = Vector2.right * _direction * _speed * _multiplierSpeed * Time.fixedDeltaTime;
            }
            else
            {
                _direction *= -1;
                _isMovingRight = !_isMovingRight;
            }
        }

        private bool CheckBoundaries()
        {
            bool outOfRightBoundary = _isMovingRight && transform.position.x > _endPos;
            bool outOfLeftBoundary = !_isMovingRight && transform.position.x < _startPos;

            if (outOfRightBoundary || outOfLeftBoundary)
            {
                return false;
            }
            return true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, new Vector2(transform.position.x + _distance, transform.position.y));
        }
    }

}
