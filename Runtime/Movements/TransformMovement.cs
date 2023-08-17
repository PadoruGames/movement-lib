using UnityEngine;

namespace Padoru.Movement
{
    public class TransformMovement : MonoBehaviour, IMovement
    {
        public Vector3 Velocity { get; private set; }

        public void Move(Vector3 velocity)
        {
            Velocity = velocity;
            
            transform.position += Velocity;
        }
    }
}