using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class TargetedParabolicMovement : MonoBehaviour
	{
		private IMovementBehaviour movementBehaviour;
		private Vector3 initialPosition;

		public Transform Target { get; set; }

		private void Awake()
		{
			movementBehaviour = GetComponent<IMovementBehaviour>();
			initialPosition = transform.position;
		}

		private void Update()
		{
			var horizontalDirection = Target.position - transform.position;
			horizontalDirection.y = 0;
			
			var timeOfFlight = Mathf.Sqrt((2 * horizontalDirection.magnitude) / gravity);

			var verticalDirection = new Vector3(0, gravity * timeOfFlight, 0);

			var finalDirection = (horizontalDirection + verticalDirection).normalized;

			movementBehaviour.TargetDirection = finalDirection;
		}
	}
}
