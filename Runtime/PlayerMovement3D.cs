using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class PlayerMovement3D : MonoBehaviour
	{
		[SerializeField] private float smoothness = 0.1f;

		private IMovementBehaviour movementBehaviour;
		private Vector3 direction;

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

			var targetDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetDirection = Vector3.ClampMagnitude(targetDirection, 1);

			direction = Vector3.Lerp(direction, targetDirection, smoothness);

			movementBehaviour.Direction = direction;
		}
	}
}
