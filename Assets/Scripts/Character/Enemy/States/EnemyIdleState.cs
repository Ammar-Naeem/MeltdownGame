using MyNamespace;
using UnityEngine;

namespace Meltdown
{
    public class EnemyIdleState : EnemyBaseState
    {
        private const float MoveSpeed = 0;
        private float _previousDotProductWithTopCyclinder;
        private float _previousDotProductWithBottomCyclinder;
        
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject enemyObject)
        {
            base.Enter(baseStateMachine, enemyObject);
            
            AnimationController.Idle();

            _previousDotProductWithTopCyclinder = GetDotProductWithTopCyclinder();
            _previousDotProductWithBottomCyclinder = GetDotProductWithBottomCyclinder();
        }

        public override void LogicUpdate()
        {

            float currentDotProductWithTopCylinder = GetDotProductWithTopCyclinder();
            float currentDotProductWithBottomCylinder = GetDotProductWithBottomCyclinder();
            
            // Debugger.DebugLog($"Current = {currentDotProductWithBottomCylinder} , Previous = {_previousDotProductWithTopCyclinder}" );
            
            if (_previousDotProductWithTopCyclinder > currentDotProductWithTopCylinder)
            {
                if (currentDotProductWithTopCylinder < -Enemy.GetCharacterForseeRatio())
                {
                    PerformCrouch();
                    return;
                }
                
            }

            if (_previousDotProductWithBottomCyclinder > currentDotProductWithBottomCylinder)
            {
                if (currentDotProductWithBottomCylinder < -Enemy.GetCharacterForseeRatio())
                {
                    PerformJump();
                    return;
                }
            }

            _previousDotProductWithTopCyclinder = currentDotProductWithTopCylinder;
            _previousDotProductWithBottomCyclinder = currentDotProductWithBottomCylinder;
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