using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private LayerMask _layerMask2;
        private Collider2D _collider;
        public bool IsGround { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IsGround = _collider.IsTouchingLayers(_layerMask);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IsGround = _collider.IsTouchingLayers(_layerMask);
        }
    }
}
