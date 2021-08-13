using UnityEngine;
using Game.SelectionMenu;

namespace Codes.CharacterControl
{

    ///<summary>
    /// Switching behaviour for players in scene.
    ///</summary>

    [RequireComponent(typeof(Selection))]

    public class SwitchPlayableCharacter : MonoBehaviour
    {

        private static SwitchPlayableCharacter INSTANCE = null;

        private Selection selection = null;

        private void Awake()
        {

            INSTANCE = this;
            selection = GetComponent<Selection>();

        }

        // The currently selected playable character for 1P.
        public static int currentlySelectedPlayer
        {

            get
            {

                if (INSTANCE == null)
                    return -1;

                return INSTANCE.selection.pointer;
            
            }
        }

    }

}