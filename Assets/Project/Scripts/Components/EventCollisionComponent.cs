using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    [RequireComponent(typeof(Collider2D))]
    public class EventCollisionComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        private Collider2D _collider;

        public UnityEvent OnCollisionEnter;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_collider.IsTouchingLayers(_layerMask))
            {
                OnCollisionEnter?.Invoke();
            }
        }
    }
}
