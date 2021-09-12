using UnityEngine;
using Game.LevelManagement;
using Game.SelectionMenu;

namespace Game.UIManagement
{
    
    ///<summary> Makes the UI button interactable. This is modified for SelectableItemAnimations. </summary>

    public class UIButtonLevelUnlocker : MonoBehaviour
    {

        [SerializeField]
        private SelectableItemAnimations _button = null;

        [SerializeField]
        private int levelIndex = 1;
        
        private void Update()
        {
            
            if (_button == null)
            {
                return;
            }

            if (_button.isInteractable)
            {
                return;
            }

            _button.isInteractable = levelIndex <= PlayerPrefs.GetInt(LevelManager.getSaveLevelKey());

        }

    }

}