using UnityEngine;
using Game;
using Game.ControlsManagement;
using Game.SpriteAnimation;
using Miscellaneous;

namespace Codes.CharacterControl
{

    ///<summary>
    /// Script for the players.
    ///</summary>

    [RequireComponent(typeof(Movement))]

    public class PlayableCharacter : MonoBehaviour
    {

        [Tooltip("Attach the Movement reference here.")]
        [SerializeField]
        private Movement movement = null;

        [Tooltip("Attach the Animations reference here.")]
        [SerializeField]
        private Animations animations = null;

        [Tooltip("Attach the Sprite Flipper reference here.")]
        [SerializeField]
        private SpriteFlipper spriteFlipper = null;

        [Tooltip("Attach the Sprite Color Editor reference here.")]
        [SerializeField]
        private SpriteColorEditor spriteColorEditor = null;

        [Tooltip("Attach the Random Rotation reference here.")]
        [SerializeField]
        private RandomRotation randomRotation = null;

        [Space]

        [Tooltip("Key for jumping.")]
        [SerializeField]
        private KeyCode keyJump = KeyCode.Space;

        [Tooltip("Button for walking.")]
        [SerializeField]
        private string buttonWalk = "Walk";

        [Space]

        [Tooltip("Its number in selection.")]
        [SerializeField]
        private int selectionNumber = -1;

        // If the objects are empty, try to get the components attached in this gameObject.
        private void Awake()
        {

            if (TryGetComponent(out Movement movement))
                this.movement = movement;

        }

        private void Update()
        {
            
            // Freeze player if game is paused.
            if (GameManager.getIsGamePause())
                return;

            Vector2 input = new Vector2(Input.GetAxisRaw(buttonWalk), 0f);

            if (selectionNumber != SwitchPlayableCharacter.currentlySelectedPlayer)
            {

                if (input != Vector2.zero)
                    movement.SetInput(Vector2.zero);

                // To avoid bug, automatically set the walkVelocity to 0.     
                AnimatePlayer(0f);

                // Make it half transparent.
                ChangeColorPlayer(0.5f);

                // Reset rotation.
                randomRotation.ResetRotation();
                
                return;

            }

            else
            {
                
                movement.SetInput(input);

                if (ControlsManager.getKeyUp(keyJump))
                {

                    movement.OnJumpInputUp();
                    randomRotation.RandomizedRotation();

                }

                if (ControlsManager.getKeyDown(keyJump))
                {

                    movement.OnJumpInputDown();
                    randomRotation.RandomizedRotation();
                
                }

            }

            // Return transparency to default.
            ChangeColorPlayer(1f);
            
            // Animate walking.
            float absWalkVelocity = Mathf.Abs(input.x);
            AnimatePlayer(absWalkVelocity);
            
            if (spriteFlipper == null)
                return;

            else
            {

                // Sprite flip.
                bool isFacingLeft = movement.platformer2D.raycastCollisions.facingDirection == -1;
                spriteFlipper.FlipHorizontal(isFacingLeft);

            }

            // Rotation of the sprite object will reset.
            if (movement.platformer2D.raycastCollisions.below)
                randomRotation.ResetRotation();

        }

        // Animate the player thru walkVelocity (initializable) and isOnGround. 
        private void AnimatePlayer(float walkVelocity)
        {

            if (animations == null)
                return;

            else
            {

                // Animate walking.
                float absWalkVelocity = walkVelocity;
                animations.Animate("walkVelocity", absWalkVelocity);

                // Animate on ground.
                bool isOnGround = movement.platformer2D.raycastCollisions.below;
                animations.Animate("isOnGround", isOnGround);

            }

        }

        // Change the player's color.
        private void ChangeColorPlayer(float alphaValue)
        {

            if (spriteColorEditor == null)
                return;

            else
            {
                
                // Make sprite transparent.
                spriteColorEditor.ChangeAlphaValue(alphaValue);
                spriteColorEditor.ChangeColor();

            }

        }

    }

}