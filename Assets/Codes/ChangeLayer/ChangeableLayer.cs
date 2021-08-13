using UnityEngine;

namespace Codes.ChangeLayer
{
    
    ///<summary>
    /// Home for changing the layer.
    ///</summary>

    public class ChangeableLayer : MonoBehaviour
    {

        // The layer id of King's and Queen's platform.
        private const byte KING_PLATFORM_LAYER_ID = 12, QUEEN_PLATFORM_LAYER_ID = 13;

        ///<summary>
        /// Changes the layer of the gameObject.
        ///</summary>
        public void ChangeLayer(GameObject objectToChangeLayer, byte newLayerID)
        {

            if (objectToChangeLayer.layer == newLayerID)
                return;

            else
            {
                objectToChangeLayer.layer = newLayerID;
            }

        }

        #region Getters 

        // Getter for KING_PLATFORM_LAYER_ID.
        public byte getKingPlatformLayerID => KING_PLATFORM_LAYER_ID;

        // Getter for QUEEN_PLATFORM_LAYER_ID.
        public byte getQueenPlatformLayerID => QUEEN_PLATFORM_LAYER_ID;

        #endregion
                
    }

}
