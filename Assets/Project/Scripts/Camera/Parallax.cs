using UnityEngine;

namespace Platformer
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private float _during;

        private float _length;
        private float _startPos;
        private const float Offset = 1.4f;

        private void Start()
        {
            _startPos = transform.position.x;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        private void Update()
        {
            float temp = (_target.transform.position.x * (1 - _during));
            float distance = (_target.transform.position.x * _during);
            transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

            if (temp > _startPos + _length - Offset)
            {
                _startPos += _length;
            }
            else if (temp < _startPos - _length + Offset)
            {
                _startPos -= _length;
            }
        }
    }
}
