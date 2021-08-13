using UnityEngine;
using UnityEngine.Events;

namespace Codes.ChangeLayer
{

    ///<summary>
    /// On specific time, changes the layer.
    ///</summary>

    public class ChangeLayerOnTime : ChangeableLayer
    {

        [Tooltip("Wait in how many seconds?")]
        [SerializeField]
        private float waitInSeconds = 4f;

        // TImer for counting deltaTime.
        private float timer = 0f;

        [Tooltip("Attach the GameObject reference here.")]
        [SerializeField]
        private GameObject objectToChangeLayer = null;

        [Space]
        
        [Tooltip("Things to do when King collided.")]
        [SerializeField]
        private UnityEvent onKingTime = new UnityEvent();

        // Currently King Platform.
        private bool isAlreadyKingPlatform = false;

        [Space]

        [Tooltip("Things to do when Queen collided.")]
        [SerializeField]
        private UnityEvent onQueenTime = new UnityEvent();

        // Currently Queen Platform.
        private bool isAlreadyQueenPlatform = false;

        private void Update()
        {
            
            // Timer ticking.
            timer += Time.deltaTime;
            
            // Change to king platform once.
            if (timer <= waitInSeconds/2)
            {
                
                if (!isAlreadyKingPlatform)
                {
                    onKingTime?.Invoke();
                    ChangeLayer(objectToChangeLayer, getKingPlatformLayerID);
                    isAlreadyKingPlatform = !isAlreadyKingPlatform;
                }

            }

            // Change to queen platform once.
            else if (timer >= waitInSeconds / 2 && timer <= waitInSeconds)
            {

                if (!isAlreadyQueenPlatform)
                {

                    onQueenTime?.Invoke();
                    ChangeLayer(objectToChangeLayer, getQueenPlatformLayerID);
                    isAlreadyQueenPlatform = !isAlreadyQueenPlatform;
                    
                }

            }

            // Reset bools and timer.
            else
            {
                timer = 0f;
                isAlreadyKingPlatform = isAlreadyQueenPlatform = false;
            }

        }

    }

}
