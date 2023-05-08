using UnityEngine;

namespace Padoru.Movement
{
    public class TransformMovementBehaviour : MonoBehaviour, IMovementBehaviour
    {
        [SerializeField] private float speed = 7;
        [SerializeField] private bool rotateTowardsVelocity = true;

        public Vector3 Direction { get; set; }
        public bool Enabled { get; set; } = true;

        private void Update()
        {
            if (!Enabled)
            {
                return;
            }

            Move(Time.deltaTime);
            if (rotateTowardsVelocity)
            {
                Rotate();
            }
        }

        private void Move(float deltaTime)
        {
            var movement = Direction * (speed * deltaTime);
            transform.position += movement;
        }

        private void Rotate()
        {
            transform.forward = Direction.normalized;
        }
    }
}