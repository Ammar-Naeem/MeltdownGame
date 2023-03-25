using UnityEngine;

namespace Meltdown
{
    public class PlayerFallingAfterJumpState : PlayerBaseState
    {
        private Camera _playerCamera;
        private Vector3 _forceDirection;

        
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            base.Enter(baseStateMachine, playerObject);
            
            Debug.Log("In JumpAfter state");
        }

        public override void LogicUpdate()
        {
            
        }

        public override void PhysicsUpdate()
        {
            //Limit Speed
            KeepPlayerInLimitedSpeed();
            
            //Free fall
            UpdateFreeFallGravityOnPlayer();

            if (IsGrounded())
            {
                ChangeStateToIdle();
            }
        }

        private void KeepPlayerInLimitedSpeed()
        {
            float maxSpeed = Player.GetMaxSpeed() / 1f;
            if (PlayerRigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
            {
                PlayerRigidbody.velocity = PlayerRigidbody.velocity.normalized * maxSpeed;
            }
        }

        public override void Exit()
        {
            Player.GetColliderTransform()
                .GetChild(0)
                .localScale = Player.GetColliderChildSizeAtStart();
        }
        
        private bool IsGrounded()
        {
            Vector3 origin = Player.GetCharacterPositionInWorld() + Vector3.up * 0.25f;

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
            BaseStateMachine.ChangeState(Player.GetPlayerStateFactory()
                .GetPlayerIdleState());
        }
        
        private void UpdateFreeFallGravityOnPlayer()
        {
            if (PlayerRigidbody.velocity.y < 0)
            {
                PlayerRigidbody.velocity -= (Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime * 20));
            }
        }
    }
}