using UnityEngine;

namespace Game.SpriteAnimation
{

    ///<summary>
    /// Changes the image.
    ///</summary>    
    
    public class ImageChanger : ImageEditor
    {

        [Tooltip("The new sprite to change.")]
        public Sprite sprite = null;

        // Change the sprite of the Image referenced.
        public void ChangeImage()
        {

            if (image.sprite == sprite)
                return;

            else
                image.sprite = sprite;

        }

    }

}

/* ORIGINAL CODE FOR SelectionItemSprite

using UnityEngine;
using UnityEngine.UI;
using Game.DebugManagement;
using Game.ControlsManagement;

namespace Game.SelectionMenu
{
    
    ///<summary>
    /// Changes sprite of selection menu.
    ///</summary>

    public class SelectionItemSprite : SelectionItem
    {

        [Space]

        [Header("Sprite Components:")]

        [Tooltip("Attach the Image reference here.")]
        public Image image = null;

        [Tooltip("The sprite in default.")]
        public Sprite spriteDefault = null;

        [Tooltip("The sprite when the index of the selection is pointing at this item.")]
        public Sprite spriteSelecting = null;

        public override void Update()
        {

            // Sprite Default
            if (selectionIndex != selection.currentIndexInSelection)
            {

                if (image.sprite == spriteDefault)
                    return;

                image.sprite = spriteDefault;
                DebugManager.ShowDebug("Default png");
                
            }

            else
            {
                
                // Selected
                if (ControlsManager.getKeyDown(selection.keySelect))
                    return;
                
                // Sprite Selecting
                else
                {

                    if (image.sprite == spriteSelecting)
                        return;

                    image.sprite = spriteSelecting;
                    DebugManager.ShowAlert("Selecting png");
                
                }
 
            }

        }

    }

}

*/