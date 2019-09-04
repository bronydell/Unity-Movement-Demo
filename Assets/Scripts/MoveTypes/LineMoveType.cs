using UnityEngine;

namespace Demo.MoveBehaviour
{
    public class LineMoveBehaviour : IMoveBehaviour
    {
        private readonly Vector2 startPoint;
        private readonly Vector2 finishPoint;

        public LineMoveBehaviour(Vector2 startPoint, Vector2 finishPoint)
        {
            this.startPoint = startPoint;
            this.finishPoint = finishPoint;
        }

        public Vector2 GetProgressPosition(float progress)
        {
            return Vector2.Lerp(startPoint, finishPoint, progress);
        }
    }
}