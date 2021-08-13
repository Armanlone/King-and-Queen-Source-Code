using UnityEngine;

namespace Game.AudioManagement
{

    ///<summary>
    /// A mini-class for playing an audio with adjustable pitch.
    ///</summary>

    public class AudioPlayerAdjustPitch : MonoBehaviour
    {
        
        public int audioID = 1;
        public float pitch = 1f;

        // Plays the audio with an adjusted pitch.
        public void PlayAdjustedPitchAudio()
        {

            if (pitch == 0)
                return;

            else
            {
                AudioManager.PlayAudioWithAdjustablePitch(audioID, pitch);
            }

        }



    }

}