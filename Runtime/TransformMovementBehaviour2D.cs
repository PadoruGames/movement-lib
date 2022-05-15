using UnityEngine;

namespace Padoru.Movement
{
	public class TransformMovementBehaviour2D : MonoBehaviour, IMovementBehaviour2D
	{
		[SerializeField] private float speed = 7;
		[SerializeField] private bool rotateTowardsVelocity = true;

		public Vector2 Direction { get; set; }
		public bool Enabled { get; set; } = true;

		private void Update()
		{
			if (!Enabled)
			{
				return;
			}

			Move(Time.deltaTime);
			if (rotateTowardsVelocity)
			{
				Rotate();
			}
		}

		private void Move(float deltaTime)
		{
			var movement = new Vector3(Direction.x, Direction.y) * speed * deltaTime;
			transform.position += movement;
		}

		private void Rotate()
		{
			if (Direction.x != 0)
			{
				var rotation = transform.eulerAngles;
				if (Direction.x > 0)
				{
					rotation.y = 0;
				}
				else if (Direction.x < 0)
				{
					rotation.y = 180;
				}
				transform.rotation = Quaternion.Euler(rotation);
			}
		}
	}
}
