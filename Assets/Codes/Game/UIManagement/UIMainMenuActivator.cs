using UnityEngine;

namespace Game.UIManagement
{

    public class UIMainMenuActivator : MonoBehaviour
    {
        
        public void IsActive(bool isActive)
        {
            UIManager.ActivateMainMenu(isActive);
        }

    }

}