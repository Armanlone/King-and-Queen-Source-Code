using UnityEngine;
using Game.DebugManagement;

namespace Game.CameraManagement
{
    
    ///<summary>
    /// Camera shakes.
    ///</summary>

    public class CameraShaker : MonoBehaviour
    {
        
        [Tooltip("Power of the shake.")]
        [SerializeField]
        private float power = 0f;

        [Tooltip("How long is the shake?")]
        [SerializeField]
        private float duration = 0f;

        // Call CameraManager to shake the camera.
        public void CameraShake()
        {

            if (duration <= 0 || power <= 0)
                DebugManager.ShowAlert("Please input the value(s) of duration, and/or power.");

            else
                CameraManager.CameraShake(power, duration);

        }

    }



}