using UnityEngine;
using Game;

namespace Miscellaneous
{
    
    public class Is1PDependent : MonoBehaviour
    {

        [SerializeField]
        private bool isSinglePlayer = true;

        private void Start()
        {

            if (GameManager.getIsSinglePlayer() == isSinglePlayer)
                Destroy(this);

            else
                Destroy(gameObject);

        }

    }

}