using UnityEngine;
using Game.ControlsManagement;
using Game;
using Game.UIManagement;

namespace Miscellaneous
{
        
    public class TriggerEndingCutscene : TriggerGoal
    {
        
        
        public override void OnTriggerStay2D(Collider2D collision)
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
                UIManager.ActivateInGameScreen(false);
                onTrigger?.Invoke();
            }

        }
        

    }

}