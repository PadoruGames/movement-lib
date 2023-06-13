using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class PlayerMovementBehaviour3D : MonoBehaviour, IMovementBehaviour
	{
		[SerializeField] private float speed = 7;
		[SerializeField] private bool useRawInput = false;
		
		private IMovement movement;

		public Vector3 Direction { get; private set; }

		private void Awake()
		{
			movement = GetComponent<IMovement>();
		}

		private void Update()
		{
			if (movement == null)
			{
				Debug.LogError("There is no Movement attached to this GameObject", gameObject);
				return;
			}

			var inputDirection = GetInputVector();
			
			Direction = Vector3.ClampMagnitude(inputDirection, 1);

			movement.Move(Direction * speed * Time.deltaTime);
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
