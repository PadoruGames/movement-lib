using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class RigidbodyMovementBehaviour2D : MonoBehaviour, IMovementBehaviour2D
	{
		[SerializeField] private float speed = 7;
		[SerializeField] private bool rotateTowardsVelocity = true;

		private Rigidbody2D rb;

		public Vector2 Direction { get; set; }

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			if(rb == null)
			{
				Debug.LogError($"Cannot move object. Null {typeof(Rigidbody2D)}");
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
			var movement = Direction * speed * deltaTime;
			rb.position += movement;
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
