using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class PlayerMovement3D : MonoBehaviour
	{
		[SerializeField] private bool useRawInput = false;
		
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

			var inputDirection = GetInputVector();
			
			inputDirection = Vector3.ClampMagnitude(inputDirection, 1);

			movementBehaviour.TargetDirection = inputDirection;
		}

		private Vector3 GetInputVector()
		{
			if (useRawInput)
			{
				return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
			}

			return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		}
	}
}
