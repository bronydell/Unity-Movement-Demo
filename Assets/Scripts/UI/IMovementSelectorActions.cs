namespace Demo
{
    public interface IMovementSelectorActions
    {
        void SetCirclesAmount(string text);
        void SetSpikeAmount(string text);
        void SetSpiralRadius(string text);
        void SetExecutionTime(string text);
        void SetMoveState(MoveState state);

        void ExecuteMove();
    }
}