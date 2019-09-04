namespace Demo
{
    public interface IMovementSelectorView
    {
        void Initialize(IMovementSelectorActions actions);
        void UpdateView(MovementSelectorModel model);
    }
}