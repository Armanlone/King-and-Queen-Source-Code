using UnityEngine;

namespace Game.ControlsManagement
{
	
	///<summary>
    /// Handles all the inputs in the game.
    ///</summary>

	public class ControlsManager : MonoBehaviour
	{

		private ControlsManager INSTANCE = null;

		private void Awake()
		{
			INSTANCE = this;
		}

		public static float getHorizontalInput(string horizontalInput)
		{
			return Input.GetAxis(horizontalInput);
		}

		// Returns 1 for up or right, and -1 for left and down.
		public static float getAxisInput(string input)
		{
			return Input.GetAxis(input);
		}

		// Returns true if the player let go of the button.
		public static bool getKeyUp(KeyCode key)
		{
			return Input.GetKeyUp(key);
		}

		// Returns true if the player pressed a button.
		public static bool getKeyDown(KeyCode key)
		{
			return Input.GetKeyDown(key);
		}

		// Returns true if the player pressed any button.
		public static bool getAnyKeyDown()
		{
			return Input.anyKeyDown;
		}

	}

}