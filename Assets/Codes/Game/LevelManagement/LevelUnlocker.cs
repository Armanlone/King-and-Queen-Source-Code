using UnityEngine;

namespace Game.LevelManagement
{
    
    ///<summary> Saves the new unlocked level. </summary>

    public class LevelUnlocker : MonoBehaviour
    {

        [Tooltip("The index of the new level unlocked.")]
        [SerializeField]
        private int newLevelUnlockedIndex = 1;

        ///<summary> Save the level. </summary>
        public void Save()
        {

            if (newLevelUnlockedIndex < LevelManager.getSaveLevel())
            {
                return;
            }

            LevelManager.setSaveLevel(newLevelUnlockedIndex);
            Debug.Log("Game Save Level: " + newLevelUnlockedIndex);
        }

    }


}
