
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Game.LevelManagement
{
    
    ///<summary>
    /// Managing scenes in the game.
    ///</summary>

    public class LevelManager : MonoBehaviour
    {
        private static LevelManager INSTANCE = null;

        private const string SAVE_LEVEL_KEY = "levelsUnlocked";

        private void Awake()
        {
            if (INSTANCE != null && INSTANCE != this)
            {
                Destroy(gameObject);
                return;
            }

            INSTANCE = this;

            Debug.Log("Level Manager created.");

            DontDestroyOnLoad(gameObject);
        }

        // Loads the room depending on its ID.
        public static void LoadLevel(int levelID)
        {

            if (INSTANCE == null)
                return;
            
            else if (levelID < 0 || levelID > SceneManager.sceneCountInBuildSettings - 1)
                return;

            else
            {

                INSTANCE.StartCoroutine(INSTANCE.AsynchronousLoadScene(levelID));

            }

        }

        // Loads the scene asynchronously.
        private IEnumerator AsynchronousLoadScene(int sceneIndex)
        {

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

            while(!asyncOperation.isDone)
            {

                float loadingProgress = Mathf.Clamp01(asyncOperation.progress/0.9f);
                Debug.Log("Loading progress: " + (loadingProgress * 100) + '%');
                
                yield return null; 

            }

        }

        #region Getter(s)
        
        public static int getCurrentSceneBuildIndex()
        {
            return SceneManager.GetActiveScene().buildIndex;
        }

        public static string getSaveLevelKey()
        {
            return SAVE_LEVEL_KEY;
        }

        public static int getSaveLevel()
        {
            return PlayerPrefs.GetInt(SAVE_LEVEL_KEY, 1);
        }

        #endregion

        #region Setter(s)

        public static void setSaveLevel(int newLevelUnlockedIndex)
        {
            PlayerPrefs.SetInt(SAVE_LEVEL_KEY, newLevelUnlockedIndex);
        }

        #endregion

    }


}