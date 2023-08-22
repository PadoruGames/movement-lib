using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class ForwardMovementBehaviour2D : MonoBehaviour, IMovementBehaviour2D
	{
		[SerializeField] private float speed = 7;
		[SerializeField] private bool getMovementFromGameObject = true;
		
		private IMovement2D movement;

		public Vector2 Direction { get; private set; }

		private void Awake()
		{
			if (getMovementFromGameObject)
			{
				SetMovement(GetComponent<IMovement2D>());
			}

			Direction = transform.right;
		}

		private void Update()
		{
			if (movement == null)
			{
				Debug.LogError("There is no Movement attached to this GameObject", gameObject);
				return;
			}

			movement.Move(Direction * speed * Time.deltaTime);;
		}

		public void SetMovement(IMovement2D movement)
		{
			this.movement = movement;
		}
	}
}
