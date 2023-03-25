using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;

namespace Meltdown
{
    public class PlayerCrouchState : PlayerBaseState
    {
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            base.Enter(baseStateMachine, playerObject);

            Debugger.DebugLog("In crouch state");
            
            PlayCrouch();
        }

        public override void LogicUpdate()
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                ChangeStateToIdle();
            }
        }

        public override void PhysicsUpdate()
        {
        }

        public override void Exit()
        {
            Player.GetColliderTransform()
                .localScale = Player.GetColliderSizeAtStart();
        }

        private void PlayCrouch()
        {
            AnimationController.Crouch();
            UpdateScaleOfCollider();
        }

        private void UpdateScaleOfCollider()
        {
            Vector3 currentScale = Player.GetColliderTransform()
                .localScale;
            currentScale.y = 0.4f;
            Player.GetColliderTransform()
                .localScale = currentScale;
        }

        private void ChangeStateToIdle()
        {
            BaseStateMachine.ChangeState(Player.GetPlayerStateFactory()
                .GetPlayerIdleState());
        }
    }
}
