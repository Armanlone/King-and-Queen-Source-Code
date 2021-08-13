using UnityEngine;

namespace Miscellaneous
{
    
    ///<summary>
    /// Rotates randomly the localRotation.
    ///</summary>

    public class RandomRotation : MonoBehaviour
    {

        [Tooltip("The gameObject to rotate.")]
        public GameObject objectToRotate = null;
        
        [Tooltip("The minimum angle of the z-axis when rotating.")]
        public float minAngle = -1f;

        [Tooltip("The maximum angle of the z-axis when rotating.")]
        public float maxAngle = 1f;

        private Vector3 originalRotation = Vector3.zero;

        private void Start()
        {
            originalRotation = transform.localEulerAngles;
        }

        // Rotate the object in random based on the max and min angles.
        public void RandomizedRotation()
        {

            Vector2 objectCurrentRotation = objectToRotate.transform.eulerAngles;
            float randomizedAngle = Random.Range(minAngle, maxAngle);
            objectToRotate.transform.localEulerAngles = new Vector3(objectCurrentRotation.x, objectCurrentRotation.y, randomizedAngle);

        }

        // Resets the rotation.
        public void ResetRotation()
        {
            objectToRotate.transform.eulerAngles = originalRotation;
        }

    }
}