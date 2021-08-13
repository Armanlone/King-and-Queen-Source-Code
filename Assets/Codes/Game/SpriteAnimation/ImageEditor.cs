using UnityEngine;
using UnityEngine.UI;

namespace Game.SpriteAnimation
{

    ///<summary>
    /// Homebase for editing Image components.
    ///</summary>    
    
    public class ImageEditor : MonoBehaviour
    {
        
        [Tooltip("Attach the Image reference here.")]
        public Image image = null;

        private void Awake()
        {

            if (image != null)
                return;
                
            else if (TryGetComponent(out Image _image))
                this.image = _image;
        
        }

    }

}