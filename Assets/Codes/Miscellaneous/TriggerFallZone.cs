using UnityEngine;
using UnityEngine.Events;

namespace Miscellaneous
{
    
    ///<summary>
    /// Triggers fall area.
    ///</summary>

    public class TriggerFallZone : MonoBehaviour
    {
        
        public UnityEvent onTrigger = new UnityEvent();

        private const string tagKing = "King", tagQueen = "Queen";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.CompareTag(tagKing) || collision.CompareTag(tagQueen))
                onTrigger?.Invoke();

        }
        

    }

}