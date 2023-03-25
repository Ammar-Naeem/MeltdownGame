using UnityEngine;

namespace Meltdown
{
    public abstract class PlayerBaseState : IBaseState
    {
        protected Player Player;
        protected CharacterAnimationController AnimationController;
        protected Rigidbody PlayerRigidbody;
        protected IBaseStateMachine BaseStateMachine;
        
        public virtual void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            Player = playerObject.GetComponent<Player>();
            
            AnimationController = Player.GetCharacterAnimationController();
            PlayerRigidbody = Player.GetCharacterRigidbody();
            
            BaseStateMachine = baseStateMachine;
        }

        public abstract void LogicUpdate();

        public abstract void PhysicsUpdate();

        public abstract void Exit();
    }
}