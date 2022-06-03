using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    [RequireComponent(typeof(Collider2D))]
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        private Collider2D _collider;

        public UnityEvent Action;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_collider.IsTouchingLayers(_layerMask))
            {
                Action?.Invoke();
            }
        }
    }
}
