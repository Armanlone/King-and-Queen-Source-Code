using UnityEngine;

namespace Game.SpriteAnimation
{

    ///<summary>
    /// Change the sprite.
    ///</summary>

    public class SpriteChanger : SpriteRendererEditor
    {
        
        [Tooltip("The new sprite to change.")]
        public Sprite newSprite = null;

        // Change the sprite of the SpriteRenderer.
        public void ChangeSprite()
        {

            if (newSprite == spriteRenderer.sprite)
                return;

            else
            {
                spriteRenderer.sprite = newSprite;
            }

        }

    }

}

