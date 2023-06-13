using UnityEngine;

namespace Padoru.Movement
{
    public class TransformMovement : MonoBehaviour, IMovement
    {
        public void Move(Vector3 velocity)
        {
            transform.position += velocity;
        }
    }
}