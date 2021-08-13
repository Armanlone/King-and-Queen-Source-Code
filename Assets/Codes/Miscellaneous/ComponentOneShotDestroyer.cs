using UnityEngine;

namespace Miscellaneous
{
        
    ///<summary>
    /// Destroyer of a component attached.
    ///</summary>

    public class ComponentOneShotDestroyer : MonoBehaviour
    {
        
        public Component component = null;

        // Destroys the component attached then destroys this.
        public void ComponentOneShot()
        {

            if (component == null)
                return;

            else
            {

                Destroy(component);
                Destroy(this);

            }

        }

    }

}