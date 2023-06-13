using System;
using UnityEngine;
using UnityEngine.Serialization;
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
		private Vector3 targetPosition;
		private Vector3 prevPosition;
		private float timeOfFlight;

		public Transform Target { get; set; }
		
		private void Awake()
		{
			movement = GetComponent<IMovement>();
		}
		
		void Start()
		{
			initialPosition = transform.position;
			targetPosition = GetTargetPosition();
		}

		private void Update()
		{
			timeOfFlight += Time.deltaTime;
			
			Move();
		}

		void Move()
		{
			prevPosition = transform.position;

			// TODO: This causes weird behaviours when targets are approaching
			targetPosition = GetTargetPosition();

			var timeProgress = timeOfFlight / duration;
			
			var currentPosition = Parabola(initialPosition, targetPosition, height, timeProgress);

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
			// TODO: Get extrapolated initial position?
			return Target.position + Vector3.up * targetPositionHeightOffset;
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawSphere(GetTargetPosition(), 0.3f);
		}
	}
}
