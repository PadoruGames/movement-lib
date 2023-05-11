using UnityEngine;

namespace Padoru.Movement
{
	public interface IMovementBehaviour2D
	{
		bool Enabled { get; set; }

		Vector2 Direction { get; }
		
		Vector2 TargetDirection { get; set; }
		
	}
}