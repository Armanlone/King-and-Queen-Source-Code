using UnityEngine;

namespace Codes.PhysicsObject
{

    public class RaycastController : MonoBehaviour
    {

        [SerializeField]
        private Collider2D _collider2D = null;

        [SerializeField]
        protected float boundsBorder = 0f, distanceBetweenRaycasts = 0f;

        protected int horizontalRaycastCount = 0, verticalRaycastCount = 0;
        protected float horizontalRaycastSpacing = 0f, verticalRaycastSpacing = 0f;

        protected RaycastPoints raycastPoints;

        //The point of origins of the raycasts on Bounds.
        protected struct RaycastPoints
        {
            public Vector2 bottomLeft, topLeft, bottomRight, topRight;
        }

        protected virtual void Start() => CalculateRaycastSpacing();

        //Updates the RaycastPoints every frame.
        protected void UpdateRaycastPoints()
        {

            Bounds bounds = _collider2D.bounds;
            if (bounds == null)
                return;

            bounds.Expand(boundsBorder * -2);

            raycastPoints.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
            raycastPoints.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
            raycastPoints.topLeft = new Vector2(bounds.min.x, bounds.max.y);
            raycastPoints.topRight = new Vector2(bounds.max.x, bounds.max.y);

        }

        //Calculates the raycasts' spacing for the horizontal and vertical raycasts.
        protected void CalculateRaycastSpacing()
        {

            Bounds bounds = _collider2D.bounds;
            if (bounds == null)
                return;

            bounds.Expand(boundsBorder * -2);

            float boundsWidth = bounds.size.y;
            float boundsHeight = bounds.size.x;

            horizontalRaycastCount = Mathf.RoundToInt(boundsHeight / distanceBetweenRaycasts);
            verticalRaycastCount = Mathf.RoundToInt(boundsWidth / distanceBetweenRaycasts);

            horizontalRaycastSpacing = boundsWidth / (horizontalRaycastCount - 1);
            verticalRaycastSpacing = boundsHeight / (verticalRaycastCount - 1);

        }

    }


}