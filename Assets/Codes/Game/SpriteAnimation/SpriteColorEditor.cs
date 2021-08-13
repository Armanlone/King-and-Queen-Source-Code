using UnityEngine;

namespace Game.SpriteAnimation
{

    ///<summary>
    /// Edits sprite's color and transparency.
    ///</summary>

    public class SpriteColorEditor : SpriteRendererEditor
    {
        
        // Color for editing.
        [SerializeField]
        private Color color = Color.white;

        // Change color's RED value.
        public void ChangeRedValue(float redValue) => color.r = redValue;
        
        // Change color's GREEN value.
        public void ChangeGreenValue(float greenValue) => color.g = greenValue;

        // Change color's BLUE value.
        public void ChangeBlueValue(float blueValue) => color.b = blueValue;

        // Change color's TRANSPARENCY.
        public void ChangeAlphaValue(float alphaValue) => color.a = alphaValue;

        // Changes the spriteRenderer's color.
        public void ChangeColor() => spriteRenderer.color = color;

    }

}