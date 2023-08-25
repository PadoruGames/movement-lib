using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
    public class ForwardMovementBehaviour : MonoBehaviour, IMovementBehaviour
    {
        [SerializeField] private float speed = 7;
        [SerializeField] private bool getMovementFromGameObject = true;

        private IMovement movement;

        public Vector3 Direction { get; private set; }
        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        private void Awake()
        {
            if (getMovementFromGameObject)
            {
                SetMovement(GetComponent<IMovement>());
            }

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

        public void SetMovement(IMovement movement)
        {
            this.movement = movement;
        }
    }
}