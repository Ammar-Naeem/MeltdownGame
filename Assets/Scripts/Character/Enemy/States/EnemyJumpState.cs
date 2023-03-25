using System.Collections;
using UnityEngine;

namespace Meltdown
{

    public class EnemyJumpState : EnemyBaseState
    {
        private const           string GroundTag        = "Ground";
        private                 bool   _isJumpPerformed = false;
        private static readonly int    s_jump           = Animator.StringToHash("Jump");

        public override void Enter(IBaseStateMachine baseStateMachine, GameObject enemyObject)
        {
            base.Enter(baseStateMachine, enemyObject);

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

            if (EnemyRigidbody.velocity.y < 0)
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
                
                Vector3 currentScale = Enemy.GetColliderTransform().GetChild(0).localScale;
                currentScale.y = 1f;
                Enemy.GetColliderTransform()
                    .GetChild(0)
                    .localScale = currentScale;

                AnimationController.Jump();

                EnemyRigidbody
                    .AddForce(Vector3.up * Enemy.GetJumpForce(), ForceMode.Impulse);
            }
            else
            {
                ChangeStateToIdle();
            }
        }

        private bool IsGrounded()
        {
            Vector3 origin = Enemy.GetCharacterPositionInWorld() + Vector3.up * 0.25f;

            Ray ray = new Ray(origin, Vector3.down);
            Debug.DrawRay(origin, Vector3.down * 0.5f, Color.green, 50);

            if (Physics.Raycast(ray, out RaycastHit hit, 0.5f, LayerHelper.GetStandLayerMask()))
            {
                return true;
            }

            return false;
        }

        private void ChangeStateToIdle()
        {
            _isJumpPerformed = false;
            BaseStateMachine.ChangeState(Enemy.GetEnemyStateFactory()
                .GetEnemyIdleState());
        }

        private void ChangeStateToJumpInAirState()
        {
            _isJumpPerformed = false;
            BaseStateMachine.ChangeState(Enemy.GetEnemyStateFactory()
                .GetEnemyJumpInAirState());
        }
    }
}
