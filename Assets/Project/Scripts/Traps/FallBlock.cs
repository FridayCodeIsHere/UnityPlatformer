using System.Collections;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallBlock : MonoBehaviour
    {
        [SerializeField] private float _timeToFall = 0f;
        private Rigidbody2D _rigidbody;

        #region MonoBehaviour
        private void OnValidate()
        {
            if (_timeToFall < 0f) _timeToFall = 0f;
        }
        #endregion


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private IEnumerator DropBlock()
        {
            yield return new WaitForSeconds(_timeToFall);
            _rigidbody.isKinematic = false;
            _rigidbody.gravityScale = 2f;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<CharacterHealth>())
            {
                StartCoroutine(DropBlock());
            }
        }
    }

}
