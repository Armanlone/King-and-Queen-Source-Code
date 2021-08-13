using UnityEngine;
using Game;
using Game.ControlsManagement;
using Codes.CharacterControl;

public class CameraColorChanger : MonoBehaviour
{

    [SerializeField]
    private Camera _camera = null;
    
    [SerializeField]
    private Color kingBlueColor = Color.white;

    [SerializeField]
    private Color queenPinkColor = Color.white;

    [SerializeField]
    private Color mixedPurpleColor = Color.white;

    public KeyCode keyChangeColor = KeyCode.DownArrow;

    private bool changeOnlyOnce = false;

    private void Update()
    {

        if (GameManager.getIsGamePause())
            return;
        
        if (GameManager.getIsSinglePlayer())
        {

            bool isKingActive = SwitchPlayableCharacter.currentlySelectedPlayer == 1;

            if (isKingActive)
            {
                _camera.backgroundColor = kingBlueColor;
            }

            else
            {
                _camera.backgroundColor = queenPinkColor;
            }


        }

        else
        {
            
            if (!changeOnlyOnce)
            {
                _camera.backgroundColor = mixedPurpleColor;
                changeOnlyOnce = true;
            }

        }

    }

}
