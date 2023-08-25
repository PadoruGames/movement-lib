using UnityEngine;

namespace Padoru.Movement
{
	public interface IMovementBehaviour
	{
		Vector3 Direction { get; }
		
		bool Enabled { get; set; }

		void SetMovement(IMovement movement);
	}
}
