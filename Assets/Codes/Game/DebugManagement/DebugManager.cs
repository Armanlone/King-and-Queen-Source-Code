using UnityEngine;

namespace Game.DebugManagement
{

    ///<summary>
    /// For debugging.
    ///</summary>
    
    public static class DebugManager
    {
        
        // Debug text in DEFAULT mode.
        public static void ShowDebug(string debugText)
        {

            if (string.IsNullOrEmpty(debugText))
                return;

            else
            {
                Debug.Log(debugText);
            }

        }

        // Debug text in ALERT mode.
        public static void ShowAlert(string debugText)
        {

            if (string.IsNullOrEmpty(debugText))
                return;

            else
            {
                Debug.LogWarning(debugText);
            }

        }

        // Debug text in ERROR mode.
        public static void ShowError(string debugText)
        {

            if (string.IsNullOrEmpty(debugText))
                return;

            else
            {
                Debug.LogError(debugText);
            }

        }

    }

}