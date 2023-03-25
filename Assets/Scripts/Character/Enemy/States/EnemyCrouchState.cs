using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;

namespace Meltdown
{
    public class EnemyCrouchState : EnemyBaseState
    {
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject enemyObject)
        {
            base.Enter(baseStateMachine, enemyObject);

            Debugger.DebugLog("In crouch state");
            
            PlayCrouch();
        }

        public override void LogicUpdate()
        {
            if (Vector3.Dot(Enemy.transform.forward, 
                Enemy.RideCylinderReference.TopCylinder.transform.forward) > -0.8f)
            {
                ChangeStateToIdle();
            }
        }

        public override void PhysicsUpdate()
        {
        }

        public override void Exit()
        {
            Enemy.GetColliderTransform()
                .localScale = Enemy.GetColliderSizeAtStart();
        }

        private void PlayCrouch()
        {
            AnimationController.Crouch();
            UpdateScaleOfCollider();
        }

        private void UpdateScaleOfCollider()
        {
            Vector3 currentScale = Enemy.GetColliderTransform()
                .localScale;
            currentScale.y = 0.4f;
            Enemy.GetColliderTransform()
                .localScale = currentScale;
        }

        private void ChangeStateToIdle()
        {
            BaseStateMachine.ChangeState(Enemy.GetEnemyStateFactory()
                .GetEnemyIdleState());
        }
    }
}