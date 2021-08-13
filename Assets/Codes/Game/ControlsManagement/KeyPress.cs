using UnityEngine;
using UnityEngine.Events;

namespace Game.ControlsManagement
{

    ///<summary>
    /// Press a key to do something.
    ///</summary>

    public class KeyPress : MonoBehaviour
    {
        
        [Tooltip("Key to press to do the things.")]
        [SerializeField]
        private KeyCode keyToPress = KeyCode.None;

        [Space]

        [Tooltip("Things to do when key pressed.")]
        [SerializeField]
        private UnityEvent onPress = new UnityEvent();

        // Just press a key to do the things, even if it's "KeyCode.None".
        private void Update()
        {

            if (keyToPress == KeyCode.None)
            {
                
                if (ControlsManager.getAnyKeyDown())
                    onPress?.Invoke();

            }

            else
            {
                
                if (ControlsManager.getKeyDown(keyToPress))
                    onPress?.Invoke();

            }

        }

    }

}