using UnityEngine;
using UnityEngine.Events;

namespace Codes.ChangeLayer
{

    ///<summary>
    /// Pressing the button changes the layer.
    ///</summary>
    
    public class ChangeLayerOnButton : ChangeableLayer
    {

        private bool isTriggerable = true;
        
        [SerializeField]
        private CheckPosition checkPosition = new CheckPosition();

        [Tooltip("Check only interactable for King, and uncheck only interactable for Queen.")]
        [SerializeField]
        private bool isKingButton = false;

        [Tooltip("Attach the GameObject reference here.")]
        [SerializeField]
        private GameObject objectToChangeLayer = null;

        [Space]

        [Tooltip("Things to do when King or Queen presses the button.")]
        [SerializeField]
        private UnityEvent onPressButton = new UnityEvent();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (!isTriggerable)
                return;

            else
            {
                
                if (isKingButton)
                {

                    // King press button.
                    if (collision.CompareTag(checkPosition.kingTransform.tag) && checkPosition.IsHigherPosition(checkPosition.kingTransform.position, transform.position))
                    {

                        ChangeLayer(objectToChangeLayer, getQueenPlatformLayerID);
                        onPressButton?.Invoke();
                        isTriggerable = false;
                    
                    }

                }

                else
                {

                    // Queen press button.
                    if (collision.CompareTag(checkPosition.queenTransform.tag) && checkPosition.IsHigherPosition(checkPosition.queenTransform.position, transform.position))
                    {

                        ChangeLayer(objectToChangeLayer, getKingPlatformLayerID);
                        onPressButton?.Invoke();
                        isTriggerable = false;
                    
                    }
                
                }

            }

        }
    }

}