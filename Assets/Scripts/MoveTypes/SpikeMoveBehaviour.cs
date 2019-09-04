using UnityEngine;

namespace Demo.MoveBehaviour
{
    public class SpikeMoveBehaviour : IMoveBehaviour
    {
        private readonly Vector2 startPoint;
        private readonly Vector2 finishPoint;
        private readonly float progressPerSpike;

        public SpikeMoveBehaviour(Vector2 startPoint, Vector2 finishPoint, int spikes)
        {
            this.startPoint = startPoint;
            this.finishPoint = finishPoint;
            progressPerSpike = 1f / spikes;
        }

        private float GetTriY(float x)
        {
            return -Mathf.Abs(2 * x % 2 - 1) + 1f;
        }

        public Vector2 GetProgressPosition(float progress)
        {
            var currentSpike = (int) (progress / progressPerSpike);
            var spikeProgress = progress - currentSpike * progressPerSpike;
            var normalizedSpikeProgress = spikeProgress / progressPerSpike;
            var spikeY = GetTriY(normalizedSpikeProgress);
            return Vector2.Lerp(startPoint, finishPoint, progress) + new Vector2(0, spikeY);
        }
    }
}