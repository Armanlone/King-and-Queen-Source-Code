using UnityEngine;
using UnityEngine.UI;

namespace Game.UIManagement
{
    
    ///<summary>
    /// Adjusts value of slider.
    ///</summary>
    
    public class UISliderValueAdjuster : MonoBehaviour
    {
        
        [Tooltip("Attach the Slider reference here.")]
        [SerializeField]
        private Slider slider = null;

        [SerializeField]
        [Range(-0.5f, 0.5f)]
        private float value = 0.5f;

        public void Adjust()
        {

            if (slider == null)
                return;

            else
            {
                UIManager.AdjustSliderValue(slider, value);
            }

        }

    }


}