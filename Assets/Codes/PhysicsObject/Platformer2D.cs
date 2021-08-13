using UnityEngine;

namespace Codes.PhysicsObject
{

    public class Platformer2D : RaycastController
    {

        [SerializeField]
        [Tooltip("The layers this object can walk to.")]
        private LayerMask layersWalkablePlatform = 0;

        [SerializeField]
        [Tooltip("The name of the tag the player can jump on to.")]
        private string tagJumpablePlatform = null;

        public RaycastCollisions raycastCollisions;

        //A collection of the GameObjects collisions.
        public struct RaycastCollisions
        {
            
            public bool above, below, left, right;
            public int facingDirection;

            //For resetting the collisions: above, below, left, right.
            public void Reset()
            {
                above = below = left = right = false;
            }

        }

        //For moving the object attached to this script.
        public void Move(Vector2 velocity)
        {

            UpdateRaycastPoints();
            raycastCollisions.Reset();

            if (velocity.x != 0)
                raycastCollisions.facingDirection = (int) Mathf.Sign(velocity.x);
            
            HorizontalCollisions(ref velocity);

            if (velocity.y != 0)
                VerticalCollisions(ref velocity);

            transform.Translate(velocity);
        }

        //Checks if the player is can bump to a platform on its horizontal axis.
        private void HorizontalCollisions(ref Vector2 velocity)
        {

            float directionX = raycastCollisions.facingDirection;
            float raycastLength = Mathf.Abs(velocity.x) + boundsBorder;

            if (Mathf.Abs(velocity.x) < boundsBorder)
                raycastLength = 2 * boundsBorder;

            for (int i = 0; i < horizontalRaycastCount; i++)
            {
                
                Vector2 raycastOrigin = (directionX == -1) ? raycastPoints.bottomLeft : raycastPoints.bottomRight;
                raycastOrigin += Vector2.up * (horizontalRaycastSpacing * i);

                RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.right * directionX, raycastLength, layersWalkablePlatform);
                Debug.DrawRay(raycastOrigin, Vector2.right * directionX, Color.red);

                if (hit)
                {

                    if (hit.collider.CompareTag(tagJumpablePlatform))
                    {

                        if (directionX == 1 || hit.distance == 0)
                            continue;

                    }

                    velocity.x = (hit.distance - boundsBorder) * directionX;
                    raycastLength = hit.distance;

                    raycastCollisions.left = directionX == -1;
                    raycastCollisions.right = directionX == 1;

                }

            }

        }

        //Checks if the player is can walk on a platform, or  jumpable platform.
        private void VerticalCollisions(ref Vector2 velocity)
        {

            float directionY = Mathf.Sign(velocity.y);
            float raycastLength = Mathf.Abs(velocity.y) + boundsBorder;

            for (int i = 0; i < verticalRaycastCount; i++)
            {
                
                Vector2 raycastOrigin = (directionY == -1) ? raycastPoints.bottomLeft : raycastPoints.topLeft;
                raycastOrigin += Vector2.right * (verticalRaycastSpacing * i + velocity.x);

                RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.up * directionY, raycastLength, layersWalkablePlatform);
                Debug.DrawRay(raycastOrigin, Vector2.up * directionY, Color.red);

                if (hit)
                {
                    
                    if (hit.collider.CompareTag(tagJumpablePlatform))
                    {

                        if (directionY == 1 || hit.distance == 0)
                            continue;

                    }

                    velocity.y = (hit.distance - boundsBorder) * directionY;
                    raycastLength = hit.distance;

                    raycastCollisions.below = directionY == -1;
                    raycastCollisions.above = directionY == 1;

                }

            }

        }

        //Starts with object's collision facing right.
        protected override void Start()
        {

            base.Start();
            raycastCollisions.facingDirection = 1;
        
        }

    }

}
