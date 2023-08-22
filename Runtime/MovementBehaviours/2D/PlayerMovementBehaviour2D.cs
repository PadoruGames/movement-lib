using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class PlayerMovementBehaviour2D : MonoBehaviour, IMovementBehaviour2D
	{
		[SerializeField] private float speed = 7;
		[SerializeField] private bool useRawInput = false;
		[SerializeField] private bool getMovementFromGameObject = true;

		private IMovement2D movement;

		public Vector2 Direction { get; private set; }

		private void Awake()
		{
			if (getMovementFromGameObject)
			{
				SetMovement(GetComponent<IMovement2D>());
			}
		}

		private void Update()
		{
			if (movement == null)
			{
				Debug.LogError("There is no Movement attached to this GameObject", gameObject);
				return;
			}

			var inputDirection = GetInputVector();
			
			Direction = Vector2.ClampMagnitude(inputDirection, 1);

			movement.Move(Direction * speed * Time.deltaTime);
		}

		public void SetMovement(IMovement2D movement)
		{
			this.movement = movement;
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