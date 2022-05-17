using UnityEngine;

using Debug = Padoru.Diagnostics.Debug;

namespace Padoru.Movement
{
	public class ForwardMovement2D : MonoBehaviour
	{
		private IMovementBehaviour2D movementBehaviour;

		private void Awake()
		{
			movementBehaviour = GetComponent<IMovementBehaviour2D>();
		}

		private void Update()
		{
			if (movementBehaviour == null)
			{
				Debug.LogError("There is no MovementBehaviour attached to this GameObject", gameObject);
				return;
			}

			movementBehaviour.Direction = transform.right;
		}
	}
}
