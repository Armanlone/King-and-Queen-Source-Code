
namespace Game.SpriteAnimation
{
    
    ///<summary>
    /// Flips the sprite.
    ///</summary>

    public class SpriteFlipper : SpriteRendererEditor
    {

        // Flip sprite HORIZONTALLY.
        public void FlipHorizontal(bool isFlip) => spriteRenderer.flipX = isFlip;

        // Flip sprite VERTICALLY.
        public void FlipVertical(bool isFlip) => spriteRenderer.flipY = isFlip;

    }

}