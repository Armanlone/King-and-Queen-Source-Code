using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    
    ///<summary>
    /// Pause/Unpause the game.
    ///</summary>

    public class GamePause : MonoBehaviour
    {

        [Tooltip("Will you use the \"Time Scale\" when pausing the game?")]
        public bool useTimeScale = true;

        [SerializeField]
        private UnityEvent onPause = new UnityEvent();

        // Manually pause/unpause.
        public void Pause(bool pause)
        {

            GameManager.setIsGamePause(pause);
            Time.timeScale = (pause && useTimeScale) ? 0 : 1;
            onPause?.Invoke();
        
        }

    }

}