using UnityEngine;


namespace Game.LevelManagement
{

    ///<summary>
    /// Loads a scene.
    ///</summary>

    public class LevelLoader : MonoBehaviour
    {

        // Calls the LevelManager to load the room.
        public void Load(int levelID)
        {

            if (levelID < 0)
                return;

            else
                LevelManager.LoadLevel(levelID);

        }

    }

}