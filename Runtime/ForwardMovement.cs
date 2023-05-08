using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
    [RequireComponent(typeof(IMovementBehaviour))]
    public class ForwardMovement : MonoBehaviour
    {
        private IMovementBehaviour movementBehaviour;

        private void Awake()
        {
            movementBehaviour = GetComponent<IMovementBehaviour>();
        }

        private void Update()
        {
            if (movementBehaviour == null)
            {
                Debug.LogError("There is no MovementBehaviour attached to this GameObject", gameObject);
                return;
            }

            movementBehaviour.Direction = transform.forward;
        }
    }
}