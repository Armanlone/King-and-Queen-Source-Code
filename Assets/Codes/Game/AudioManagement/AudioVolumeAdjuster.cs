using UnityEngine;

namespace Game.AudioManagement
{
    
    ///<summary>
    /// Adjusts volume depending on audio type.
    ///</summary>

    public class AudioVolumeAdjuster : MonoBehaviour
    {
        
        [Tooltip("The type of the audio: SFX, BGM, and etc. Default is None.")]
        [SerializeField]
        private AudioType audioType = AudioType.None;

        [Tooltip("Fade In = increasing the volume. Fade Out = decreasing the volume.")]
        [SerializeField]
        private FadeType fadeType = FadeType.FadeIn;

        [Tooltip("Value to be added.")]
        [Range(0.1f, 0.5f)]
        [SerializeField]
        private float value = 0.5f;

        // Adjusting the volume through AudioManager.
        public void Adjust()
        {

            if (audioType == AudioType.None) { return; }

            else
            {
                AudioManager.AdjustVolume(audioType, fadeType, value);
            }

        }

    }

}
