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
        }

        private void PlayCrouch()
        {
            AnimationController.Crouch();
            
        }
        
        private void ChangeStateToIdle()
        {
            BaseStateMachine.ChangeState(Player.GetPlayerStateFactory()
                .GetPlayerIdleState());
        }
    }
}
