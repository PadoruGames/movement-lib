using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class RigidbodyMovement2D : MonoBehaviour, IMovement2D
	{
		private Rigidbody2D rb;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void Move(Vector2 velocity)
		{
			if (rb == null)
			{
				Debug.LogError("Cannot move, RigidBody is null!");
				return;
			}
			
			rb.position += velocity;
		}
	}
}
