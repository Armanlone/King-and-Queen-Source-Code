using UnityEngine;
using UnityEngine.Events;
using Game.ControlsManagement;

namespace Game.SelectionMenu
{
    
    ///<summary>
    /// Item you can select through Selection script.
    ///</summary>

    public class SelectableItem : MonoBehaviour
    {

        [Tooltip("The Selection script it belongs to.")]
        [SerializeField]
        protected Selection selection = null;

        [Tooltip("Its index in the selection.")]
        [SerializeField]
        protected byte selectionIndex = 1;

        [Tooltip("Is this interactable?")]
        public bool isInteractable = true;

        [Space]

        // Things to do at idle.
        [SerializeField]
        protected UnityEvent onDefault = new UnityEvent();

        [Space]

        // Things to do when the pointer is pointing to this.
        [SerializeField]
        protected UnityEvent onPointer = new UnityEvent();
        
        [Space]

        // Things to do when this is selected.
        [SerializeField]
        protected UnityEvent onSelected = new UnityEvent();

        // @Overriding.
        public virtual void OnEnable()
        {

        }

        public virtual void Update()
        {
            
            // Prevent errors...
            if (selection == null || selection.keySelect == KeyCode.None || !isInteractable)
                return;

            // DEFAULT STATE
            if (selectionIndex != selection.pointer)
                onDefault?.Invoke();

            else
            {
                
                // POINTER STATE
                if (!Input.GetKeyDown(selection.keySelect))
                    onPointer?.Invoke();

                // SELECTED STATE
                else
                    onSelected?.Invoke();

            }


        }

    }

}

/*

ANIMATION SCRIPT:

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

*/