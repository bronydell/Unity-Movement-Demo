using System;
using System.Collections;
using Demo.MoveBehaviour;
using UnityEngine;

namespace Demo.MoveExecutor
{
    public class UnityMoveExecutor : MonoBehaviour, IMoveExecutor
    {
        private Coroutine moveCoroutine;

        public void ExecuteMove(Transform target, IMoveBehaviour move, float executionTime, Action onFinish)
        {
            moveCoroutine = StartCoroutine(MoveCoroutine(target, move, executionTime, onFinish));
        }

        private static IEnumerator MoveCoroutine(
            Transform target,
            IMoveBehaviour move,
            float executionTime,
            Action onFinish
        )
        {
            var timeElapsed = 0f;
            while (timeElapsed < executionTime)
            {
                var executionProgress = timeElapsed / executionTime;
                target.position = move.GetProgressPosition(executionProgress);
                yield return null;
                timeElapsed += Time.deltaTime;
            }

            onFinish();
        }
    }
}