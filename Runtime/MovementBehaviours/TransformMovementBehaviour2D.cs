using UnityEngine;

namespace Padoru.Movement
{
	public class TransformMovementBehaviour2D : MonoBehaviour, IMovementBehaviour2D
	{
		[SerializeField] private float speed = 7;
		[SerializeField] private float smoothness = 0.1f;
		[SerializeField] private bool rotateTowardsVelocity = true;

		private Vector2 direction;
		
		public Vector2 Direction => direction;
		public Vector2 TargetDirection { get; set; }
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
			direction = Vector2.Lerp(direction, TargetDirection, smoothness);
			var movement = new Vector3(direction.x, direction.y) * (speed * deltaTime);
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
