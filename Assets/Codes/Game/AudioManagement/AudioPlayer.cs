using UnityEngine;

namespace Game.AudioManagement
{

    ///<summary>
    /// A mini-class for playing an audio.
    ///</summary>

    public class AudioPlayer : MonoBehaviour
    {

        public void PlayAudio(int audioID)
        {

            if (audioID < 0)
                return;

            else
            {
                AudioManager.PlayAudio(audioID);
            }

        }

    }

}