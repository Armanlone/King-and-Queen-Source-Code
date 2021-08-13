using UnityEngine;

namespace Codes.ChangeLayer
{
    
    ///<summary>
    /// Checks positions of the objects.
    ///</summary>

    [System.Serializable]
    public class CheckPosition
    {

        [Tooltip("Want to check the position of players?")]
        public bool isCheckPosition = true;

        [Tooltip("Attach the Transform reference of the King here.")]
        public Transform kingTransform = null;

        [Tooltip("Attach the Transform reference of the Queen here.")]    
        public Transform queenTransform = null;
        
        ///<summary>
        /// Checks if the objectA's Y position is higher than objectB's Y posiiton.
        ///</summary>
        public bool IsHigherPosition(Vector3 objectPositionA, Vector3 objectPositionB)
        {
            return objectPositionA.y > objectPositionB.y;
        }

    }

}