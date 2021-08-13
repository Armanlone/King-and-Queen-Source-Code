using UnityEngine;


namespace Game.LevelManagement
{

    ///<summary>
    /// Loads next scene base from current scene.
    ///</summary>

    public class NextSceneLoader : MonoBehaviour
    {

        // Calls the LevelManager to load the next scene.
        public void Load() => LevelManager.LoadLevel(LevelManager.getCurrentSceneBuildIndex() + 1);

    }

}