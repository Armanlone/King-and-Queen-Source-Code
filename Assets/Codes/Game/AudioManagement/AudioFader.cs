using UnityEngine;

namespace Game.AudioManagement
{

    ///<summary>
    /// A mini-class for fading in/out an audio.
    ///</summary>

    public class AudioFader : MonoBehaviour
    {

        public int audioID = -1;

        public FadeType fadeType = FadeType.FadeIn;

        [Tooltip("How fast is the fade of the sound?")]
        [Range(0.5f, 1f)]
        [SerializeField]
        private float fadeSpeed = 0.5f;
        
        // Fades the audio.
        public void Fade()
        {

            if (audioID <= -1 || fadeSpeed <= 0f)
                return;

            else if (fadeType == FadeType.FadeIn)
            {
                AudioManager.FadeIn(fadeSpeed, audioID);
            }

            else
            {
                AudioManager.FadeOut(fadeSpeed, audioID);
            }

        }

    }

}