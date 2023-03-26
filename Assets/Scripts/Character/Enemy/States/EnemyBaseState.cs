using UnityEngine;

namespace Meltdown
{
    public abstract class EnemyBaseState : IBaseState
    {
        protected Enemy                       Enemy;
        protected CharacterAnimationController AnimationController;
        protected Rigidbody                    EnemyRigidbody;
        protected IBaseStateMachine            BaseStateMachine;
        
        public virtual void Enter(IBaseStateMachine baseStateMachine, GameObject enemyObject)
        {
            Enemy = enemyObject.GetComponent<Enemy>();
            
            AnimationController = Enemy.GetCharacterAnimationController();
            EnemyRigidbody     = Enemy.GetCharacterRigidbody();
            
            BaseStateMachine = baseStateMachine;
        }

        public abstract void LogicUpdate();

        public abstract void PhysicsUpdate();

        public abstract void Exit();

        protected float GetDotProductWithTopCyclinder()
        {
            float withTopCyclinderDotProduct = Vector3.Dot(Enemy.transform.forward,
                Enemy.RideCylinderReference.TopCylinder.transform.up);

            return withTopCyclinderDotProduct;
        }
        
        protected float GetDotProductWithBottomCyclinder()
        {
            float withBottomCyclinderDotProduct = Vector3.Dot(Enemy.transform.forward, 
                Enemy.RideCylinderReference.BottomCylinder.transform.up);

            return withBottomCyclinderDotProduct;
        }
    }
}