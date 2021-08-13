using UnityEngine;
using UnityEngine.Events;
using Game.ControlsManagement;
using Game;
using Game.UIManagement;

namespace Miscellaneous
{
        
    ///<summary>
    /// Triggers the goal.
    ///</summary>

    public class TriggerGoal : MonoBehaviour
    {
        
        protected const string tagKing = "King", tagQueen = "Queen";

        protected bool isKingColliding = false, isQueenColliding = false;

        [Tooltip("Key to enter next level.")]
        [SerializeField]
        protected KeyCode keyEnterNextLevel = KeyCode.Return;
        
        [Space]
        
        [SerializeField]
        protected UnityEvent onTrigger = new UnityEvent();

        public virtual void OnTriggerStay2D(Collider2D collision)
        {
            
            // King in on the trigger zone.
            if (collision.CompareTag(tagKing))
                isKingColliding = true;

            // Queen in on the trigger zone.
            if (collision.CompareTag(tagQueen))
                isQueenColliding = true;

            // Do the things to do when king and queen are inside trigger zone and player pressed next level.
            if (ControlsManager.getKeyDown(keyEnterNextLevel) && (isQueenColliding && isKingColliding))
            {
                UIManager.ActivateLevelCleared(true);
                UIManager.ActivateInGameScreen(false);
                GameManager.setIsGamePause(true);
                onTrigger?.Invoke();
            }

        }
        
        private void OnTriggerExit2D(Collider2D collision)
        {

            // King left the trigger zone.
            if (collision.CompareTag(tagKing))
                isKingColliding = false;

            // Queen left the trigger zone.
            if (collision.CompareTag(tagQueen))
                isQueenColliding = false;

        }

    }

}