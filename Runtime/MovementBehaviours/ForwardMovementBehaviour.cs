using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
    [RequireComponent(typeof(IMovement))]
    public class ForwardMovementBehaviour : MonoBehaviour, IMovementBehaviour
    {
        [SerializeField] private float speed = 7;

        private IMovement movement;

        public Vector3 Direction { get; private set; }

        private void Awake()
        {
            movement = GetComponent<IMovement>();

            Direction = transform.forward;
        }

        private void Update()
        {
            if (movement == null)
            {
                Debug.LogError("There is no Movement attached to this GameObject", gameObject);
                return;
            }

            movement.Move(Direction * speed * Time.deltaTime);
        }
    }
}