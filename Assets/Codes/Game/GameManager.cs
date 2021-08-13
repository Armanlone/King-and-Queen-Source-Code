
namespace Game
{
    
    ///<summary>
    /// Handles this game logics.
    ///<summary>

    public class GameManager
    {

        private static GameManager INSTANCE = null;

        // Bools for generic game.
        private bool IsGamePause = false;

        // Bools explicitly for King & Queen game. 
        private bool IsSinglePlayer = true;

        // Doesn't use Unity's Awake() to return an instance in Singleton method.
        private static GameManager getInstance()
        {

            if (INSTANCE == null)
            {
                INSTANCE = new GameManager();
            }
            
            return INSTANCE;

        }

        #region Setter(s)

        public static void setIsGamePause(bool isGamePause)
        {
            getInstance().IsGamePause = isGamePause;
        }

        public static void setIsSinglePlayer(bool isSinglePlayer)
        {
            getInstance().IsSinglePlayer = isSinglePlayer;
        }

        #endregion

        #region Getter(s)
        
        public static bool getIsGamePause()
        {
            return getInstance().IsGamePause;
        }

        public static bool getIsSinglePlayer()
        {
            return getInstance().IsSinglePlayer;
        }

        #endregion

    }

}

/* OLD SCRIPT:


namespace Game
{
    
    ///<summary>
    /// Handles this game logics.
    ///<summary>

    public class GameManager
    {

        private static GameManager INSTANCE = null;

        // Bools for generic game.
        private bool IsGamePause = false;
        private bool IsGameRestart = false;
        private bool IsLevelCleared = false;

        // Bools explicitly for King & Queen game. 
        private bool IsSinglePlayer = true;
        private bool IsSomebodyFell = false;

        // Doesn't use Unity's Awake() to return an instance in Singleton method.
        private static GameManager getInstance()
        {

            if (INSTANCE == null)
            {
                INSTANCE = new GameManager();
            }
            
            return INSTANCE;

        }

        #region Setter(s)
        public static void setIsGamePause(bool isGamePause)
        {
            getInstance().IsGamePause = isGamePause;
        }

        public static void setIsGameRestart(bool isGameRestart)
        {
            getInstance().IsGameRestart = isGameRestart;
        }

        public static void setIsSinglePlayer(bool isSinglePlayer)
        {
            getInstance().IsSinglePlayer = isSinglePlayer;
        }

        public static void setIsSomebodyFell(bool isSomebodyFell)
        {
            getInstance().IsSomebodyFell = isSomebodyFell;
        }
        
        public static void setIsLevelCleared(bool isLevelCleared)
        {
            getInstance().IsLevelCleared = isLevelCleared;
        }

        #endregion

        #region Getter(s)
        
        public static bool getIsGamePause()
        {
            return getInstance().IsGamePause;
        }

        public static bool getIsGameRestart()
        {
            return getInstance().IsGameRestart;
        }

        public static bool getIsSinglePlayer()
        {
            return getInstance().IsSinglePlayer;
        }

        public static bool getIsSomebodyFell()
        {
            return getInstance().IsSomebodyFell;
        }

        public static bool getIsLevelCleared()
        {
            return getInstance().IsLevelCleared;
        }

        #endregion

    }

}

*/