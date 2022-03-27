using UnityEngine;

namespace Padoru.Movement
{
	public class CharacterControllerMovementBehaviour : MonoBehaviour, IMovementBehaviour
	{
		[SerializeField] private CharacterController cc;
		[SerializeField] private float speed = 7;
		[SerializeField] private bool rotateTowardsVelocity = true;

		public Vector3 Direction { get; set; }

		private void Update()
		{
			if (cc == null)
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
			var movement = Direction * speed * deltaTime;
			cc.Move(movement);
		}

		private void Rotate()
		{
			if (Direction != Vector3.zero)
			{
				cc.transform.rotation = Quaternion.LookRotation(Direction);
			}
		}
	}
}
