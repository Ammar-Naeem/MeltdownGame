using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meltdown
{
    public class PlayerCrouchState : PlayerBaseState
    {
        public override void Enter(IBaseStateMachine baseStateMachine, GameObject playerObject)
        {
            base.Enter(baseStateMachine, playerObject);
        }

        public override void LogicUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void PhysicsUpdate()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}
