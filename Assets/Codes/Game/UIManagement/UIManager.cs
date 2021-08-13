using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.UIManagement
{
    
    ///<summary>
    /// Allows user inputs for the system.
    ///</summary>

    public class UIManager : MonoBehaviour
    {

        private static UIManager INSTANCE = null;

        [Tooltip("Attach the Main Menu reference here.")]
        [SerializeField]
        private GameObject objMainMenu = null;

        [Tooltip("Attach the Instructions reference here.")]
        [SerializeField]
        private GameObject objInstructions = null;

        [Tooltip("Attach the Level Cleared reference here.")]
        [SerializeField]
        private GameObject objLevelCleared = null;

        [Tooltip("Attach the Pause Screen reference here.")]
        [SerializeField]
        private GameObject objInGameScreen = null;

        [Tooltip("Attach the Transition Canvas Group reference here.")]
        [SerializeField]
        private CanvasGroup cnvgTransition = null;

        private void Awake()
        {
            if (INSTANCE != null && INSTANCE != this)
            {
                Destroy(gameObject);
                return;
            }

            INSTANCE = this;

            Debug.Log("UI Manager created.");

            DontDestroyOnLoad(gameObject);
            
        }

        ///<summary>
        /// Activates/deactivates the "Level Cleared" gameObject. :)  
        ///</summary>
        public static void ActivateLevelCleared(bool isActive)
        {

            if (INSTANCE == null || INSTANCE.objLevelCleared == null)
                return;

            else
            {
                INSTANCE.objLevelCleared.SetActive(isActive);
            }

        }

        ///<summary>
        /// Activates/deactivates the "In-game Screen" gameObject. :)  
        ///</summary>
        public static void ActivateInGameScreen(bool isActive)
        {

            if (INSTANCE == null || INSTANCE.objInGameScreen == null)
                return;

            else
            {
                INSTANCE.objInGameScreen.SetActive(isActive);
            }

        }

        ///<summary>
        /// Activates/deactivates the "Main Menu" gameObject. :)  
        ///</summary>
        public static void ActivateMainMenu(bool isActive)
        {

            if (INSTANCE == null || INSTANCE.objMainMenu == null)
                return;

            else
            {
                INSTANCE.objMainMenu.SetActive(isActive);
            }

        }

        ///<summary>
        /// Activates/deactivates the "Instructions" gameObject. :)  
        ///</summary>
        public static void ActivateInstructions(bool isActive)
        {

            if (INSTANCE == null || INSTANCE.objInstructions == null)
                return;

            else
            {
                INSTANCE.objInstructions.SetActive(isActive);
            }

        }

        // Fades in/out the canvas group.
        public static void Fade(CanvasGroup canvasGroup, float endValue, float duration)
        {

            if (INSTANCE == null || canvasGroup == null)
                return;

            else
            {
                canvasGroup.DOFade(endValue, duration);
            }

        }

        // Adjusts slider's value.
        public static void AdjustSliderValue(Slider slider, float value)
        {

            if (INSTANCE == null || slider == null)
                return;

            else if ((slider.value < slider.minValue) || (slider.value > slider.maxValue))
                return;

            else
            {
                slider.value += value;
            }

        }

        #region Setter(s)
        
        public void setIsSinglePlayer(bool isSinglePlayer) => GameManager.setIsSinglePlayer(isSinglePlayer);
        
        #endregion

        #region Getter(s)

        public static CanvasGroup getCanvasGroupTransition()
        {
            return INSTANCE.cnvgTransition;
        }

        #endregion
    }

}