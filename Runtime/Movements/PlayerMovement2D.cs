using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class PlayerMovement2D : MonoBehaviour
	{
		[SerializeField] private bool useRawInput = false;

		private IMovementBehaviour2D movementBehaviour;

		private void Awake()
		{
			movementBehaviour = GetComponent<IMovementBehaviour2D>();
		}

		private void Update()
		{
			if (movementBehaviour == null)
			{
				Debug.LogError("There is no MovementBehaviour attached to this GameObject", gameObject);
				return;
			}

			var inputDirection = GetInputVector();
			inputDirection = Vector2.ClampMagnitude(inputDirection, 1);

			movementBehaviour.TargetDirection = inputDirection;
		}

		private Vector2 GetInputVector()
		{
			if (useRawInput)
			{
				return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			}

			return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}
	}
}