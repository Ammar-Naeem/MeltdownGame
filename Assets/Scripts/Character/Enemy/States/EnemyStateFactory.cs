namespace Meltdown
{
    public class EnemyStateFactory
    {
        private IBaseState _enemyIdleState;
        private IBaseState _enemyJumpState;
        private IBaseState _enemyJumpInAirState;
        private IBaseState _enemyCrouchState;
        
        public EnemyStateFactory()
        {
            _enemyIdleState      = new EnemyIdleState();
            _enemyJumpState      = new EnemyJumpState();
            _enemyJumpInAirState = new EnemyFallingAfterJumpState();
            _enemyCrouchState    = new EnemyCrouchState();
        }
        
        public IBaseState GetEnemyIdleState()
        {
            return _enemyIdleState;
        }
        
        public IBaseState GetEnemyJumpState()
        {
            return _enemyJumpState;
        }
        
        public IBaseState GetEnemyJumpInAirState()
        {
            return _enemyJumpInAirState;
        }

        public IBaseState GetEnemyCrouchState()
        {
            return _enemyCrouchState;
        }
    }
}