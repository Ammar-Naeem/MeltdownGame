using System;
using UnityEngine;

namespace Meltdown
{
    public class Character : MonoBehaviour, IInitializer
    {
        [Header("Movement Values:")] 
        [SerializeField]                     private float _jumpForce     = 5    ;
        [SerializeField]                     private float _maxSpeed      = 5;

        [Header("Collision Values:")] [SerializeField]
        private Transform colliderTransform;
        
        //Controllers
        private CharacterAnimationController _characterAnimationController;
        
        //Local References
        private Rigidbody _characterRigidbody;
        private Vector3 _colliderSizeAtStart;

        //State controller
        protected IBaseStateMachine CharacterPhysicalStateMachine;
        
        //Getters
        public CharacterAnimationController GetCharacterAnimationController() => _characterAnimationController;
        public Rigidbody GetCharacterRigidbody() => _characterRigidbody;
        
        public float GetJumpForce() => _jumpForce;
        public float GetMaxSpeed() => _maxSpeed;
        public Vector3 GetCharacterPositionInWorld() => transform.position;
        
        //Colliders
        public Transform GetColliderTransform() => colliderTransform;
        public Vector3 GetColliderSizeAtStart() => _colliderSizeAtStart;

        private void Start()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            Animator characterAnimator  = GetComponentInChildren<Animator>();
            _characterRigidbody = GetComponent<Rigidbody>();
            
            _characterAnimationController = new CharacterAnimationController(characterAnimator);

            CharacterPhysicalStateMachine = new PlayerPhysicalStateMachine(gameObject);

            _colliderSizeAtStart = colliderTransform.localScale;
        }

        private void Update()
        {
            CharacterPhysicalStateMachine.GetCurrentState().LogicUpdate();
        }

        private void FixedUpdate()
        {
            CharacterPhysicalStateMachine.GetCurrentState().PhysicsUpdate();
        }

    }
}