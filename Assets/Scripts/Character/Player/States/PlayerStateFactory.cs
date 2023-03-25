namespace Meltdown
{
    public class PlayerStateFactory
    {
        private IBaseState _playerIdleState;
        private IBaseState _playerJumpState;
        private IBaseState _playerJumpInAirState;
        private IBaseState _playerCrouchState;
        
        public PlayerStateFactory()
        {
            _playerIdleState = new PlayerIdleState();
            _playerJumpState = new PlayerJumpState();
            _playerJumpInAirState = new PlayerFallingAfterJumpState();
            _playerCrouchState = new PlayerFallingAfterJumpState();
        }
        
        public IBaseState GetPlayerIdleState()
        {
            return _playerIdleState;
        }
        
        public IBaseState GetPlayerJumpState()
        {
            return _playerJumpState;
        }
        
        public IBaseState GetPlayerJumpInAirState()
        {
            return _playerJumpInAirState;
        }
    }
}
