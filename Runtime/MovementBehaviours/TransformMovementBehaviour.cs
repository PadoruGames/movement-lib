using UnityEngine;

namespace Padoru.Movement
{
    public class TransformMovementBehaviour : MonoBehaviour, IMovementBehaviour
    {
        [SerializeField] private float speed = 7;
        [SerializeField] private float smoothness = 0.1f;
        [SerializeField] private bool rotateTowardsVelocity = true;

        private Vector3 direction;
        
        public Vector3 Direction => direction;
        public Vector3 TargetDirection { get; set; }
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
            direction = Vector3.Lerp(direction, TargetDirection, smoothness);
            
            var movement = direction * (speed * deltaTime);
            
            transform.position += movement;
        }

        private void Rotate()
        {
            if (TargetDirection == Vector3.zero)
            {
                return;
            }
            
            var targetRotation = Quaternion.LookRotation(TargetDirection, Vector3.up);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness);
        }
    }
}