using UnityEngine;

namespace Meltdown
{
    public class Enemy : Character
    {
        //State controller
        private readonly EnemyStateFactory _enemyStateFactory = new EnemyStateFactory();
        
        //Getters
        public EnemyStateFactory GetEnemyStateFactory() => _enemyStateFactory;
        
        public override void Initialize()
        {
            base.Initialize();
            
            CharacterPhysicalStateMachine.ChangeState(_enemyStateFactory.GetPlayerIdleState());
        }

    }
}