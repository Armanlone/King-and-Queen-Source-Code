using UnityEngine;
using Game.ControlsManagement;
using Game.SpriteAnimation;

namespace Game.SelectionMenu
{
    
    ///<summary>
    /// Item that's animated.
    ///</summary>

    [RequireComponent(typeof(Animations))]
    public class SelectableItemAnimations : SelectableItem
    {

        [Space]

        [Header("Animations")]

        [Tooltip("Attach the Animations reference here.")]
        [SerializeField]
        private Animations animations = null;

        [Tooltip("Name of the animation parameter: \"state\".")]
        [SerializeField]
        private string parameterNameState = "state";

        private int animationState = 1, storedAnimationState = 0;

        private void Awake()
        {
            
            if (animations == null)
            {

                if (TryGetComponent(out Animations _animations))
                {
                    this.animations = _animations;
                }

            }

        }

        public override void OnEnable()
        {

            animationState = 1;
            SelectableItemAnimationState();

        }

        public override void Update()
        {
            
            // Prevent errors...
            if (selection == null || selection.keySelect == KeyCode.None)
                return;

            // NOT INTERACTABLE STATE
            if (!isInteractable)
            {
                //animationState = 4;

                // Not interactable and Idle
                if (selectionIndex != selection.pointer)
                {
                    animationState = 4;
                }

                // Not interactable and Pointing
                else if (!ControlsManager.getKeyDown(selection.keySelect))
                {
                    animationState = 3;
                }
                
            }

            else
            {

                // DEFAULT STATE
                if (selectionIndex != selection.pointer)
                {
                    onDefault?.Invoke();
                    animationState = 1;
                }

                else
                {
                    
                    // POINTER STATE
                    if (!ControlsManager.getKeyDown(selection.keySelect))
                    {

                        onPointer?.Invoke();
                        animationState = 2;
                    
                    }

                    // SELECTED STATE
                    else
                    {
                        onSelected?.Invoke();
                    }

                }

            }

            SelectableItemAnimationState();

        }

        private void SelectableItemAnimationState()
        {

            if (animations == null)
                return;

            else
            {
                
                // Animate the state only once so it doesn't repeat animation.
                if (animationState == storedAnimationState)
                    return;

                else
                {

                    animations.Animate(parameterNameState, animationState);
                    storedAnimationState = animationState;

                }

            }
        
        }

    }

}

