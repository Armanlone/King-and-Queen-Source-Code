using UnityEngine;
using Game.ControlsManagement;

namespace Game.SelectionMenu
{
    
    ///<summary> Item that changes sprite depending on its state. </summary>

    public class SelectableItemSprite : SelectableItem
    {
        
        [Space]

        [Header("Sprites")]

        [Tooltip("Attach the Sprite Renderer reference here.")]
        [SerializeField]
        private SpriteRenderer spriteRenderer = null;

        [Tooltip("Sprite in IDLE state.")]
        [SerializeField]
        private Sprite spriteDefault = null;

        [Tooltip("Sprite when POINTER is pointing to this state.")]
        [SerializeField]
        private Sprite spriteOnPointer = null;

        [Tooltip("Sprite in SELECTED state.")]
        [SerializeField]
        private Sprite spriteSelected = null;

        [Tooltip("Sprite when this is NOT INTERACTABLE state.")]
        [SerializeField]
        private Sprite spriteNotInteractable = null;

        private byte animationState = 1, storedAnimationState = 0;

        private void Awake()
        {
            
            if (spriteRenderer == null)
            {

                if (TryGetComponent(out SpriteRenderer _spriteRenderer))
                {
                    this.spriteRenderer = _spriteRenderer;
                }

            }

        }

        public override void OnEnable() => animationState = 1;

        public override void Update()
        {

            // Prevent errors...
            if (selection == null || selection.keySelect == KeyCode.None)
                return;

            // NOT INTERACTABLE STATE
            if (!isInteractable)
            {
                animationState = 4;
            }

            // DEFAULT STATE
            else if (selectionIndex != selection.pointer)
            {
                onDefault?.Invoke();
                animationState = 1;
            }

            else
            {
                
                // POINTER STATE
                if (!Input.GetKeyDown(selection.keySelect))
                {

                    onPointer?.Invoke();
                    animationState = 2;
                
                }

                // SELECTED STATE
                else
                {

                   onSelected?.Invoke();
                   animationState = 3;

                }

            }

            SelectableItemAnimationState();

        }

        ///<summary> Handles animations and sprites of this item. </summary>
        private void SelectableItemAnimationState()
        {

            if (spriteRenderer == null)
                return;

            else
            {
                
                // Animate the state only once so it doesn't repeat animation.
                if (animationState == storedAnimationState)
                    return;

                else
                {

                    
                    switch (animationState)
                    {

                        case 1:

                            spriteRenderer.sprite = spriteDefault; 
                            break;
                        
                        case 2: 
                            
                            spriteRenderer.sprite = spriteOnPointer; 
                            break;
                        
                        case 3: 
                            
                            spriteRenderer.sprite = spriteSelected;
                            break;

                        case 4: 
                        
                            spriteRenderer.sprite = spriteNotInteractable;
                            break;

                        default:
                        
                            break;
                    }

                    storedAnimationState = animationState;

                }

            }
        
        }

    }

}