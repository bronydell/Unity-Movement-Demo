using System;
using UnityEngine;

namespace Demo.MoveBehaviour
{
    public class SpiralMoveBehaviour : IMoveBehaviour
    {
        private readonly Vector2 center;
        private readonly float circlesRadians;
        private readonly float padding;

        public SpiralMoveBehaviour(Vector2 center, float radius, int circles)
        {
            this.center = center;
            circlesRadians = Mathf.PI * (circles * 360) / 180.0f;
            padding = radius / circles;
        }
        
        public Vector2 GetProgressPosition(float progress)
        {
            var angle = circlesRadians - circlesRadians * progress;
            var x = (padding * angle) * Mathf.Cos(angle);
            var y = (padding * angle) * Mathf.Sin(angle);

            return center + new Vector2(x, y);
        }
    }
}