using UnityEngine;

namespace Game.UIManagement
{

    public class UIInstructions : MonoBehaviour
    {
        
        public void IsActive(bool isActive)
        {
            UIManager.ActivateInstructions(isActive);
        }

    }

}