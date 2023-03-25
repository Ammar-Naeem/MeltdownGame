using UnityEngine;

namespace Meltdown
{
    public class PlayerIdleState : PlayerBaseState
    {
        private const float MoveSpeed = 0;
        
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            base.Enter(baseStateMachine, playerObject);
            
            Debug.Log("In Idle state");
            
            AnimationController.Idle();
        }

        public override void LogicUpdate()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
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
            BaseStateMachine.ChangeState(Player.GetPlayerStateFactory().GetPlayerJumpState());
        }
    }
}