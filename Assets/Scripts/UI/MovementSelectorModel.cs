using UnityEngine;

namespace Demo
{
    public enum MoveState { Line, Spikes, Spiral }
    public enum UiState { Waiting, InProgress }

    public class MovementSelectorModel
    {
        public Transform Target { get; set; }
        public Vector2 LineStartPoint { get; set; }
        public Vector2 LineFinishPoint { get; set; }

        public Vector2 SpikeStartPoint { get; set; }
        public Vector2 SpikeFinishPoint { get; set; }

        public Vector2 SpiralCenterPoint { get; set; }

        public UiState CurrentUiState { get; set; } = UiState.Waiting;
        public MoveState CurrentMoveState { get; set; } = MoveState.Line;
        public float ExecutionTime { get; set; }
        public int Spikes { get; set; }
        public int Circles { get; set; }
        public float Radius { get; set; }
    }
}