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
            if (selection == null || selection.keySelect == KeyCode.None)
                return;

            // DEFAULT STATE
            if (selectionIndex != selection.pointer)
                onDefault?.Invoke();

            else
            {
                
                // POINTER STATE
                if (!ControlsManager.getKeyDown(selection.keySelect))
                    onPointer?.Invoke();

                // SELECTED STATE
                else
                    onSelected?.Invoke();

            }


        }

    }

}