using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class VelocityRotator : MonoBehaviour
	{
		[SerializeField] private float rotationSmoothness = 0.1f;

		private Vector3 previousPosition;
		private Vector3 currentPosition;

		private void Awake()
		{
			previousPosition = transform.position;
			currentPosition = previousPosition;
		}
		
		private void Update()
		{
			previousPosition = currentPosition;
			currentPosition = transform.position;
			
			var velocity = currentPosition - previousPosition;
			Rotate(velocity);
		}

		private void Rotate(Vector3 velocity)
		{
			if (velocity == Vector3.zero)
			{
				return;
			}
			
			var targetRotation = Quaternion.LookRotation(velocity, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothness);
		}
	}
}
