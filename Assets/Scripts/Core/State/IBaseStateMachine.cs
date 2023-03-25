namespace Meltdown
{
    public interface IBaseStateMachine
    {
        public IBaseState GetCurrentState();
        public void ChangeState(IBaseState baseState);
    }
}