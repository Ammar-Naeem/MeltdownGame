using UnityEngine;

namespace Meltdown
{
    public class Player : Character
    {
        //State controller
        private readonly PlayerStateFactory _playerStateFactory = new PlayerStateFactory();
        
        //Getters
        public PlayerStateFactory GetPlayerStateFactory() => _playerStateFactory;
        
        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            
            CharacterPhysicalStateMachine.ChangeState(_playerStateFactory.GetPlayerIdleState());
        }

    }
}