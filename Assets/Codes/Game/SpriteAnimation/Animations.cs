using UnityEngine;

namespace Game.SpriteAnimation
{

    ///<summary>
    /// Animates this object.
    ///</summary>

    public class Animations : MonoBehaviour
    {
        
        [Tooltip("Attach the Animator reference here.")]
        [SerializeField]
        private Animator animator = null;

        // Gets attached Animator if animator isn't initialized.
        private void Awake()
        {
            
            if (animator != null)
                return;

            else
            {

                if (TryGetComponent(out Animator _animator))
                    this.animator = _animator;

            }

        }

        // Do the animation using TRIGGER.
        public void Animate(string name)
        {

            if (animator == null || string.IsNullOrEmpty(name))
                return;

            else
            {

                int animationID = Animator.StringToHash(name);
                animator.SetTrigger(animationID);

            }

        }

        // Do the animation using BOOLEAN.
        public void Animate(string name, bool value)
        {

            if (animator == null || string.IsNullOrEmpty(name))
                return;

            else
            {

                int animationID = Animator.StringToHash(name);
                animator.SetBool(animationID, value);

            }

        }

        // Do the animation using FLOAT.
        public void Animate(string name, float value)
        {

            if (animator == null || string.IsNullOrEmpty(name))
                return;

            else
            {

                int animationID = Animator.StringToHash(name);
                animator.SetFloat(animationID, value);

            }

        }

        // Do the animation using INTEGER.
        public void Animate(string name, int value)
        {

            if (animator == null || string.IsNullOrEmpty(name))
                return;

            else
            {

                int animationID = Animator.StringToHash(name);
                animator.SetInteger(animationID, value);

            }

        }

        /* Test code using is and object data type.
        // Do the animation.
        public void Animate(string name, object value)
        {

            if (animator == null || string.IsNullOrEmpty(name))
                return;

            int animationID = Animator.StringToHash(name);

            if (value is bool)
            {
                animator.SetBool(animationID, value);
            }

            else if (value is float)
            {
                animator.SetFloat(animationID, value);
            }

            else if (value is int)
            {
                animator.SetInteger(animationID, value);
            }

            else
            {
                animator.SetTrigger(animationID);
            }

        }
        */
    }

}