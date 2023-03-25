using UnityEngine;

namespace Meltdown
{
    public class EnemyIdleState : EnemyBaseState
    {
        private const float MoveSpeed = 0;
        
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            base.Enter(baseStateMachine, playerObject);
            
            AnimationController.Idle();
        }

        public override void LogicUpdate()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                PerformJump();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                PerformCrouch();
            }
        }

        public override void PhysicsUpdate()
        {
        }

        public override void Exit()
        {
        }

        private void PerformJump()
        {
            BaseStateMachine.ChangeState(Enemy.GetEnemyStateFactory().GetEnemyJumpState());
        }
        
        private void PerformCrouch()
        {
            BaseStateMachine.ChangeState(Enemy.GetEnemyStateFactory().GetEnemyCrouchState());
        }
    }
}