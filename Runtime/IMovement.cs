using UnityEngine;

namespace Padoru.Movement
{
	public interface IMovement
	{
		Vector3 Velocity { get; }
		
		void Move(Vector3 velocity);
	}
}
