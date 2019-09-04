using System;
using Demo.MoveExecutor;
using UnityEngine;

namespace Demo
{
    public class MovementSelectorStarter : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Transform startPoint;
        [SerializeField]
        private Transform endPoint;
        [SerializeField]
        private Transform centerPoint;

        [SerializeField]
        private MovementSelectorView view;
        [SerializeField]
        private UnityMoveExecutor moveExecutor;

        [SerializeField]
        private int defaultCircles;
        [SerializeField]
        private int defaultSpikes;
        [SerializeField]
        private float defaultExecutionTime;
        [SerializeField]
        private float defaultRadius;

        private void Awake()
        {
            var lineEnd = endPoint.position;
            var lineStart = startPoint.position;
            var model = new MovementSelectorModel
            {
                Target = target,
                LineStartPoint = lineStart,
                LineFinishPoint = lineEnd,
                SpikeStartPoint = lineStart,
                SpikeFinishPoint = lineEnd,
                SpiralCenterPoint = centerPoint.position,
                Circles = defaultCircles,
                Spikes = defaultSpikes,
                ExecutionTime = defaultExecutionTime,
                Radius = defaultRadius
            };

            var movementSelectorController = new MovementSelectorController(moveExecutor, view, model);
        }
    }
}