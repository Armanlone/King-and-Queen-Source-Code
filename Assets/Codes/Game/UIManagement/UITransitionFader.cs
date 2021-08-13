using UnityEngine;

namespace Game.UIManagement
{

    ///<summary>
    /// Fades in/out the Transition.
    ///</summary>

    public class UITransitionFader : MonoBehaviour
    {

        [Tooltip("The end value of alpha of the Canvas Group.")]
        [SerializeField]
        [Range(0f, 1f)]
        private float alphaEndValue = 1f;

        [Tooltip("The duration of fade.")]
        [SerializeField]
        [Range(0f, 1f)]
        private float duration = 1f;

        // Fades the Transition.
        public void Fade()
        {

            if (UIManager.getCanvasGroupTransition() == null || alphaEndValue <= -1f || duration <= -1f) 
                return;

            UIManager.Fade(UIManager.getCanvasGroupTransition(), alphaEndValue, duration);

        }

    }   
}