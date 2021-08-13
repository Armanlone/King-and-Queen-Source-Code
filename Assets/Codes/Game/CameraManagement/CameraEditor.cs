using UnityEngine;

namespace Game.CameraManagement
{

    ///<summary>
    /// Homebase for editing Camera components.
    ///</summary> 
        
    public class CameraEditor : MonoBehaviour
    {

        private Camera _camera = null;

        private void Awake()
        {
            _camera = CameraManager.getCamera();
        }

    }
}