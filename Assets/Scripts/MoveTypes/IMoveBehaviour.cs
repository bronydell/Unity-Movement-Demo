using UnityEngine;

namespace Demo.MoveBehaviour
{
    public interface IMoveBehaviour
    {
        Vector2 GetProgressPosition(float progress);
    }
}