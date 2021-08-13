using UnityEngine;
using Game.DebugManagement;

namespace Miscellaneous
{
	
	///<summary>
	/// Sine-wave motion.
	///</summary>

	[RequireComponent(typeof(Rigidbody2D))]
	public class MovementSineWave : MonoBehaviour
	{

		[Tooltip("Attach the Rigidbody2D reference here.")]
		[SerializeField]
		private Rigidbody2D rb2D = null;

		[Space]

		[Header("Sine Wave")]

		[Tooltip("Type of sine wave it does.")]
		[SerializeField]
		private SineWaveType sineWaveType = SineWaveType.None;

		[Tooltip("The number of times it curves up and down.")]
		[SerializeField]
		private float frequency = 0f;

		[Tooltip("The height of the curve in up and down motion.")]
		[SerializeField]
		private float amplitude = 0f;

		private void Awake()
		{

			if (rb2D != null)
				return;

			else if (TryGetComponent(out Rigidbody2D rb2D))
				this.rb2D = rb2D;

		}

		public void Update()
		{

			float x = 0f, y = 0f;

			switch(sineWaveType)
			{

				// Moves in a vertical sine wave.
				case SineWaveType.Vertical:

					x = rb2D.velocity.x;
					y = Mathf.Sin(Time.time * frequency) * amplitude;

					break;

				// Moves in a horizontal sine wave.
				case SineWaveType.Horizontal:

					float speed = 2f, pi = 3.14f;

					x = Mathf.Cos(Time.time * frequency) * amplitude;
					y = Mathf.Sin(pi * speed * Time.time * frequency) * amplitude;

					break;

				// Moves in a circle sine wave.
				case SineWaveType.Circle:

					x = Mathf.Cos(Time.time * frequency) * amplitude;
					y = Mathf.Sin(Time.time * frequency) * amplitude;

					break;

				// Doesn't move.
				default:

					DebugManager.ShowDebug("Please choose a sine wave type.");
					
					break;

			}

			rb2D.velocity = new Vector2(x, y);

		}

		// The type of sine wave movement it will do.
		public enum SineWaveType
		{

			Vertical,
			Horizontal,
			Circle,
			None

		}

	}

}