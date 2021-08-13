using UnityEngine;

namespace Game.SelectionMenu
{
    
    ///<summary>
    /// Gameboy Selection: Navigating and selecting in the menu through buttons. (Up, Down, and Select) 
    ///</summary>

    public class Selection : MonoBehaviour
    {

        [Tooltip("The starting index in selection.")]
        [SerializeField]
        private int startingIndex = -1;

        [Tooltip("The size of the items in selection.")]
        [SerializeField]
        private int itemsSize = -1;

        //The current index in the selection.
        public int pointer { private set; get; }

        [Tooltip("The key for moving the pointer at the previous item.")]
        [SerializeField]
        private KeyCode keyChooseBack = KeyCode.UpArrow;

        [Tooltip("The key for moving the pointer to the next item.")]
        [SerializeField]
        private KeyCode keyChooseNext = KeyCode.DownArrow;

        [Tooltip("The key to select an item in the selection.")]
        public KeyCode keySelect = KeyCode.Return;

        //Point the pointer to the starting index.
        private void OnEnable()
        {
            pointer = startingIndex;
            Debug.LogWarning("Currently selected item: " + pointer);
        }

        private void Update()
        {

            // Do nothing if both the length and starting index are -1 or the pointer isn't pointing to starting index.
            if (startingIndex == -1 || itemsSize == -1 || pointer == 0)
                return;

            else
            {

                // The downward selection: 1 - 2 - 3 - 4 - ...
                if (Input.GetKeyDown(keyChooseNext))
                {

                    pointer++;

                    if (pointer > itemsSize)
                    {
                        pointer = startingIndex;
                    }

                    Debug.LogWarning("Currently selected item: " + pointer);

                }

                // The upward selection: 4 - 3 - 2 - 1 - ...
                else if (Input.GetKeyDown(keyChooseBack))
                {

                    pointer--;

                    if (pointer < 1)
                    {
                        pointer = itemsSize;
                    }

                    Debug.LogWarning("Currently selected item: " + pointer);

                }

            }

        }

    }

}