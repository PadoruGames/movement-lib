using UnityEngine;

namespace Padoru.Movement
{
	public class TransformMovement2D : MonoBehaviour, IMovement2D
	{
		public void Move(Vector2 velocity)
		{
			transform.position += new Vector3(velocity.x, velocity.y);
		}
	}
}
