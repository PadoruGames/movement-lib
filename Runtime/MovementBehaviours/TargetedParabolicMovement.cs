using System;
using UnityEngine;
using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class TargetedParabolicMovement : MonoBehaviour
	{
		[SerializeField] private float duration = 7;
		[SerializeField] private float height = 7;
		[SerializeField] private float targetPositionHeightOffset = 1;
		
		private readonly float gravity = 9.8f;
		
		private IMovement movement;
		private Vector3 initialPosition;
		private Vector3 prevPosition;
		private float timeOfFlight;

		// TODO: Get extrapolated initial position
		public Vector3 TargetPosition { get; set; }
		
		private void Awake()
		{
			movement = GetComponent<IMovement>();
		}
		
		void Start()
		{
			initialPosition = transform.position;
		}

		private void Update()
		{
			timeOfFlight += Time.deltaTime;
			
			Move();
		}

		void Move()
		{
			prevPosition = transform.position;

			var timeProgress = timeOfFlight / duration;
			
			var currentPosition = Parabola(initialPosition, GetTargetPosition(), height, timeProgress);

			var velocity = currentPosition - prevPosition;
			
			movement.Move(velocity);
		}
		
		private Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
		{
			Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

			var mid = Vector3.Lerp(start, end, t);

			return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
		}
		
		private Vector3 GetTargetPosition()
		{
			return TargetPosition + Vector3.up * targetPositionHeightOffset;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(GetTargetPosition(), 0.2f);
		}
	}
}
