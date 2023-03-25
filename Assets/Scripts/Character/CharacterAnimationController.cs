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
            _characterAnimator.SetTrigger(_animatorIdleValue);
        }

        public void Jump()
        {
            _characterAnimator.SetTrigger(_animatorJumpValue);
        }

        public void Crouch()
        {
            _characterAnimator.SetTrigger(_animatorCrouchValue);
        }
    }
}
