using UnityEngine;

namespace Game.DebugManagement
{
    
    ///<summary>
    /// A debug.
    ///</summary>

    public class Debugger : MonoBehaviour
    {

        [Tooltip("Type of the debug: \"Default\", \"Alert\", or \"Error\"")]
        [SerializeField]
        private DebugType debugType = DebugType.Default;

        [Tooltip("Debug message")]
        [SerializeField]
        [TextArea]
        private string text = "Input message here.";

        public void ShowDebug()
        {

            if (string.IsNullOrEmpty(text))
                return;

            else
            {

                switch (debugType)
                {

                    case DebugType.Default:
                        DebugManager.ShowDebug(text);
                        break;

                    case DebugType.Alert:
                        DebugManager.ShowAlert(text);
                        break;
                    
                    case DebugType.Error:
                        DebugManager.ShowError(text);
                        break;

                }

            }

        }

    }

}