using UnityEngine;

namespace Meltdown
{
    public interface IBaseState
    {
        public void Enter(IBaseStateMachine baseStateMachine, GameObject referenceObject);
        public void LogicUpdate();
        public void PhysicsUpdate();
        public void Exit();
    }
}
