using System.Collections;
using UnityEngine;

namespace Meltdown
{

    public class PlayerJumpState : PlayerBaseState
    {
        private const           string GroundTag        = "Ground";
        private                 bool   _isJumpPerformed = false;
        private static readonly int    s_jump           = Animator.StringToHash("Jump");

        public override void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            base.Enter(baseStateMachine, playerObject);

            Debug.Log("In Jump state");
            PerformJump();
        }

        public override void LogicUpdate()
        {
        }

        public override void PhysicsUpdate()
        {
            if (!_isJumpPerformed)
            {
                return;
            }

            if (PlayerRigidbody.velocity.y < 0)
            {
                // ChangeStateToIdle();
                ChangeStateToJumpInAirState();
            }
        }


        public override void Exit()
        {
        }

        private void PerformJump()
        {
            if (_isJumpPerformed)
            {
                return;
            }

            if (IsGrounded())
            {
                _isJumpPerformed = true;
                
                Vector3 currentScale = Player.GetColliderTransform().GetChild(0).localScale;
                currentScale.y = 1f;
                Player.GetColliderTransform()
                    .GetChild(0)
                    .localScale = currentScale;

                AnimationController.Jump();

                PlayerRigidbody
                    .AddForce(Vector3.up * Player.GetJumpForce(), ForceMode.Impulse);
            }
            else
            {
                ChangeStateToIdle();
            }
        }

        private bool IsGrounded()
        {
            Vector3 origin = Player.GetCharacterPositionInWorld() + Vector3.up * 0.25f;

            Ray ray = new Ray(origin, Vector3.down);
            Debug.DrawRay(origin, Vector3.down * 0.5f, Color.green, 50);

            if (Physics.Raycast(ray, out RaycastHit hit, 0.5f))
            {
                return true;
            }

            return false;
        }

        private void ChangeStateToIdle()
        {
            _isJumpPerformed = false;
            BaseStateMachine.ChangeState(Player.GetPlayerStateFactory()
                .GetPlayerIdleState());
        }

        private void ChangeStateToJumpInAirState()
        {
            _isJumpPerformed = false;
            BaseStateMachine.ChangeState(Player.GetPlayerStateFactory()
                .GetPlayerJumpInAirState());
        }
    }
}
