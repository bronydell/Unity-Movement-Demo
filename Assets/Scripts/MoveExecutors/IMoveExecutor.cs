using System;
using Demo.MoveBehaviour;
using UnityEngine;

namespace Demo.MoveExecutor
{
    public interface IMoveExecutor
    {
        void ExecuteMove(
            Transform target,
            IMoveBehaviour move,
            float executionTime,
            Action onFinish
        );
    }
}