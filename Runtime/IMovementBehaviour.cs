using UnityEngine;

namespace Padoru.Movement
{
	public interface IMovementBehaviour
	{
		bool Enabled { get; set; }

		Vector3 TargetDirection { get; set; }
		
		Vector3 Direction { get; }
	}
}
