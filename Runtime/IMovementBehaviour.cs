using UnityEngine;

namespace Padoru.Movement
{
	public interface IMovementBehaviour
	{
		Vector3 Direction { get; }

		void SetMovement(IMovement movement);
	}
}
