using UnityEngine;

namespace Meltdown
{
    public class PlayerPhysicalStateMachine : IBaseStateMachine
    {
        private readonly GameObject _playerGameobject;
        private IBaseState _currentState;

        public PlayerPhysicalStateMachine(GameObject playerGameobject)
        {
            _playerGameobject = playerGameobject;
        }

        public IBaseState GetCurrentState()
        {
            return _currentState;
        }

        public void ChangeState(IBaseState newBaseState)
        {
            _currentState?.Exit();

            _currentState = newBaseState;
            
            _currentState.Enter(this, _playerGameobject);
        }
    }
}
