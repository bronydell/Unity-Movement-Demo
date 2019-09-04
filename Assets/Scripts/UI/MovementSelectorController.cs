using System;
using Demo.MoveBehaviour;
using Demo.MoveExecutor;

namespace Demo
{
    public class MovementSelectorController : IMovementSelectorActions
    {
        private IMoveExecutor moveExecutor;
        private IMovementSelectorView view;
        private MovementSelectorModel model;

        public MovementSelectorController(
            IMoveExecutor moveExecutor,
            IMovementSelectorView view,
            MovementSelectorModel model
        )
        {
            this.view = view;
            this.moveExecutor = moveExecutor;
            this.model = model;

            view.Initialize(this);
            view.UpdateView(model);
        }

        public void ExecuteMove()
        {
            OnStartMove();
            switch (model.CurrentMoveState)
            {
                case MoveState.Line:
                    ExecuteLineMove();
                    break;
                case MoveState.Spikes:
                    ExecuteSpikesMove();
                    break;
                case MoveState.Spiral:
                    ExecuteSpiralMove();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(model.CurrentMoveState), model.CurrentMoveState, null);
            }
        }


        private void ExecuteMove(IMoveBehaviour move)
        {
            moveExecutor.ExecuteMove(model.Target, move, model.ExecutionTime, OnFinishMove);
        }

        private void ExecuteLineMove()
        {
            var move = new LineMoveBehaviour(
                model.LineStartPoint,
                model.LineFinishPoint
            );
            ExecuteMove(move);
        }

        private void ExecuteSpikesMove()
        {
            var move = new SpikeMoveBehaviour(
                model.SpikeStartPoint,
                model.SpikeFinishPoint,
                model.Spikes
            );
            ExecuteMove(move);
        }

        private void ExecuteSpiralMove()
        {
            var move = new SpiralMoveBehaviour(
                model.SpiralCenterPoint,
                model.Radius,
                model.Circles
            );
            ExecuteMove(move);
        }

        private void OnStartMove()
        {
            model.CurrentUiState = UiState.InProgress;
            UpdateView();
        }

        private void OnFinishMove()
        {
            model.CurrentUiState = UiState.Waiting;
            UpdateView();
        }

        public void SetCirclesAmount(string text)
        {
            if (int.TryParse(text, out var circles))
            {
                model.Circles = circles;
                UpdateView();
            }
        }

        public void SetSpikeAmount(string text)
        {
            if (int.TryParse(text, out var spikes))
            {
                model.Spikes = spikes;
                UpdateView();
            }
        }

        public void SetSpiralRadius(string text)
        {
            if (!text.EndsWith(".") && float.TryParse(text, out var radius))
            {
                model.Radius = radius;
                UpdateView();
            }
        }

        public void SetExecutionTime(string text)
        {
            if (!text.EndsWith(".") && float.TryParse(text, out var executionTime))
            {
                model.ExecutionTime = executionTime;
                UpdateView();
            }
        }

        public void SetMoveState(MoveState state)
        {
            model.CurrentMoveState = state;
            UpdateView();
        }

        private void UpdateView()
        {
            view.UpdateView(model);
        }
    }
}