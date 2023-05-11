using UnityEngine;

namespace Padoru.Movement
{
	public class CharacterControllerMovementBehaviour : MonoBehaviour, IMovementBehaviour
	{
		[SerializeField] private CharacterController cc;
		[SerializeField] private float speed = 7;
		[SerializeField] private float smoothness = 0.1f;
		[SerializeField] private bool rotateTowardsVelocity = true;

		private Vector3 direction;
		
		public Vector3 Direction => TargetDirection;
		public bool Enabled { get; set; }
		public Vector3 TargetDirection { get; set; }

		private void Update()
		{
			if (!Enabled || cc == null)
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
			direction = Vector3.Lerp(direction, TargetDirection, smoothness);
			var movement = direction * (speed * deltaTime);
			cc.Move(movement);
		}

		private void Rotate()
		{
			if (TargetDirection == Vector3.zero)
			{
				return;
			}
			
			var targetRotation = Quaternion.LookRotation(TargetDirection, Vector3.up);
			cc.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness);
		}
	}
}
