using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class PlayerMovement2D : MonoBehaviour
	{
		[SerializeField] private float smoothness = 0.1f;
		[SerializeField] private bool useRawInput = false;

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

			Vector2 targetDirection;
			if (useRawInput)
			{
				targetDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
			}
			else
			{
				targetDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			}

			targetDirection = Vector2.ClampMagnitude(targetDirection, 1);

			direction = useRawInput ? targetDirection : Vector2.Lerp(direction, targetDirection, smoothness);

			movementBehaviour.Direction = direction;
		}
	}
}