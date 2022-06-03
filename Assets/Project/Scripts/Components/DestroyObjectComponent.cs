using UnityEngine;

namespace Platformer
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestroy;

        public void Destroy()
        {
            Destroy(_objectToDestroy);
        }
    }
}
