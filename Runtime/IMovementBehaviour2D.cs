using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public interface IMovementBehaviour2D
	{
		Vector2 Direction { get; }

		void SetMovement(IMovement2D movement);
	}
}
