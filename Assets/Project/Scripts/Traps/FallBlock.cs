using System.Collections;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallBlock : MonoBehaviour
    {
        [SerializeField] private float _timeToFall = 0f;

        #region MonoBehaviour
        private void OnValidate()
        {
            if (_timeToFall < 0f) _timeToFall = 0f;
        }
        #endregion

        private Rigidbody2D _rigidbody;


        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Drop()
        {
            StartCoroutine(DropBlock());
        }

        private IEnumerator DropBlock()
        {
            yield return new WaitForSeconds(_timeToFall);
            _rigidbody.isKinematic = false;
            _rigidbody.gravityScale = 2f;
        }
    }

}
