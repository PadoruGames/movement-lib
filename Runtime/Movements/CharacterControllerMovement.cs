using UnityEngine;

namespace Padoru.Movement
{
	public class CharacterControllerMovement : MonoBehaviour, IMovement
	{
		[SerializeField] private CharacterController cc;
		
		public void Move(Vector3 velocity)
		{
			if (cc == null)
			{
				Debug.LogError("CharacterController is null, cannot move!");
				return;
			}
			
			cc.Move(velocity);
		}
	}
}
