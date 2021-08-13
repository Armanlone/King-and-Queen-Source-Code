using UnityEngine;

namespace Game.SpriteAnimation
{
        
    ///<summary>
    /// Homebase for editing SpriteRenderer components.
    ///</summary>

    public class SpriteRendererEditor : MonoBehaviour
    {
    
        [Tooltip("Attach the SpriteRenderer reference here.")]
        public SpriteRenderer spriteRenderer = null;

        private void Awake()
        {
            
            if (spriteRenderer != null)
                return;
                
            else
            {

                if (TryGetComponent(out SpriteRenderer _spriteRenderer))
                    this.spriteRenderer = _spriteRenderer;

            }

        }

    }

}