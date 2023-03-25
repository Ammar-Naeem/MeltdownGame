using UnityEngine;

namespace Meltdown
{
    public class EnemyIdleState : EnemyBaseState
    {
        private const float MoveSpeed = 0;
        
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject enemyObject)
        {
            base.Enter(baseStateMachine, enemyObject);
            
            AnimationController.Idle();
        }

        public override void LogicUpdate()
        {
            if (Vector3.Dot(Enemy.transform.forward, 
                Enemy.RideCylinderReference.TopCylinder.transform.up) < -0.9f)
            {
                PerformCrouch();
            }
            else if (Vector3.Dot(Enemy.transform.forward, 
                Enemy.RideCylinderReference.BottomCylinder.transform.up) < -0.9f)
            {
                PerformJump();
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