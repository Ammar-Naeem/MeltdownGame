using UnityEngine;

namespace Meltdown
{
    public class EnemyFallingAfterJumpState : EnemyBaseState
    {
        private Camera _enemyCamera;
        private Vector3 _forceDirection;

        
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject enemyObject)
        {
            base.Enter(baseStateMachine, enemyObject);
            
            Debug.Log("In JumpAfter state");
        }

        public override void LogicUpdate()
        {
            
        }

        public override void PhysicsUpdate()
        {
            //Limit Speed
            KeepEnemyInLimitedSpeed();
            
            //Free fall
            UpdateFreeFallGravityOnEnemy();

            if (IsGrounded())
            {
                ChangeStateToIdle();
            }
        }

        private void KeepEnemyInLimitedSpeed()
        {
            float maxSpeed = Enemy.GetMaxSpeed() / 1f;
            if (EnemyRigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
            {
                EnemyRigidbody.velocity = EnemyRigidbody.velocity.normalized * maxSpeed;
            }
        }

        public override void Exit()
        {
            Enemy.GetColliderTransform()
                .GetChild(0)
                .localScale = Enemy.GetColliderChildSizeAtStart();
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
            BaseStateMachine.ChangeState(Enemy.GetEnemyStateFactory()
                .GetEnemyIdleState());
        }
        
        private void UpdateFreeFallGravityOnEnemy()
        {
            if (EnemyRigidbody.velocity.y < 0)
            {
                EnemyRigidbody.velocity -= (Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime * 20));
            }
        }
    }
}