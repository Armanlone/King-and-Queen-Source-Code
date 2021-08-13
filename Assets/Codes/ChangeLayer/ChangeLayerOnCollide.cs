using UnityEngine;
using UnityEngine.Events;

namespace Codes.ChangeLayer
{

    ///<summary>
    /// On collision, changes the layer once.
    ///</summary>

    public class ChangeLayerOnCollide : ChangeableLayer
    {

        // Only collideable once.
        private bool isCollidable = true;

        [Space]

        [SerializeField]
        private CheckPosition checkPosition = null;

        [Space]

        [Tooltip("Things to do when King collided.")]
        [SerializeField]
        private UnityEvent onKingCollided = new UnityEvent();

        [Space]

        [Tooltip("Things to do when Queen collided.")]
        [SerializeField]
        private UnityEvent onQueenCollided = new UnityEvent();

        // When either King or Queen is on top of this platform.
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (!isCollidable)
                return;

            else if (checkPosition.kingTransform == null || checkPosition.queenTransform == null)
                return;

            else
            {

                if (collision.CompareTag(checkPosition.kingTransform.tag))
                {

                    bool canChangeLayer = true;

                    if (checkPosition.isCheckPosition)
                        canChangeLayer = checkPosition.IsHigherPosition(checkPosition.kingTransform.position, transform.position);

                    if (canChangeLayer)
                    {
                        ChangeLayer(this.gameObject, getKingPlatformLayerID);
                        onKingCollided?.Invoke();
                        
                        isCollidable = false;
                    }
                
                }

                else if (collision.CompareTag(checkPosition.queenTransform.tag))
                {

                    bool canChangeLayer = true;

                    if (checkPosition.isCheckPosition)
                        canChangeLayer = checkPosition.IsHigherPosition(checkPosition.queenTransform.position, transform.position);

                    if (canChangeLayer)
                    {
                        ChangeLayer(this.gameObject, getQueenPlatformLayerID);
                        onQueenCollided?.Invoke();
                        
                        isCollidable = false;
                    }
                
                }

            }

        }

    }

}