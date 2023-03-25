using MyNamespace;
using UnityEngine;

namespace Meltdown
{
    public class CharacterAnimationController
    {
        private readonly Animator _characterAnimator;

        private readonly int _animatorIdleValue = Animator.StringToHash("idle");
        private readonly int _animatorJumpValue = Animator.StringToHash("jump");
        private readonly int _animatorCrouchValue = Animator.StringToHash("crouch");
        
        public CharacterAnimationController(Animator animator)
        {
            _characterAnimator = animator;
        }

        public void Idle()
        {
            ResetAllTriggers();

            Debugger.DebugLog("Idle animation plyaing");
            _characterAnimator.SetTrigger(_animatorIdleValue);
        }

        public void Jump()
        {
            ResetAllTriggers();

            Debugger.DebugLog("Jump animation plyaing");

            _characterAnimator.SetTrigger(_animatorJumpValue);
        }

        public void Crouch()
        {
            ResetAllTriggers();
            Debugger.DebugLog("Crouch animation plyaing");

            _characterAnimator.SetTrigger(_animatorCrouchValue);
        }

        private void ResetAllTriggers()
        {
            _characterAnimator.ResetTrigger(_animatorIdleValue);
            _characterAnimator.ResetTrigger(_animatorJumpValue);
            _characterAnimator.ResetTrigger(_animatorCrouchValue);
        }
    }
}
