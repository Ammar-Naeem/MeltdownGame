using System;
using MyNamespace;
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
        
        [Header("AI")] [SerializeField] private float characterForseeRatio = 0.95f;
        
        //Controllers
        private CharacterAnimationController _characterAnimationController;
        
        //Local References
        private Rigidbody _characterRigidbody;
        private Vector3 _colliderSizeAtStart;
        private Vector3 _colliderChildSizeAtStart;
        private RideCylinderReference _rideCylinderReference;

        //State controller
        protected IBaseStateMachine CharacterPhysicalStateMachine;
        
        //Getters
        public CharacterAnimationController GetCharacterAnimationController() => _characterAnimationController;
        public Rigidbody GetCharacterRigidbody() => _characterRigidbody;
        
        public float GetJumpForce() => _jumpForce;
        public float GetMaxSpeed() => _maxSpeed;
        public Vector3 GetCharacterPositionInWorld() => transform.position;

        public float GetCharacterForseeRatio() => characterForseeRatio;
        
        //Colliders
        public Transform GetColliderTransform() => colliderTransform;
        public Vector3 GetColliderSizeAtStart() => _colliderSizeAtStart;
        public Vector3 GetColliderChildSizeAtStart() => _colliderChildSizeAtStart;
        
        //Setters
        public RideCylinderReference RideCylinderReference
        {
            set => _rideCylinderReference = value;
            get => _rideCylinderReference;
        }

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
            _colliderChildSizeAtStart = colliderTransform.GetChild(0)
                .localScale;
        }

        private void Update()
        {
            CharacterPhysicalStateMachine.GetCurrentState().LogicUpdate();
        }

        private void FixedUpdate()
        {
            CharacterPhysicalStateMachine.GetCurrentState().PhysicsUpdate();
        }

        private void OnCollisionEnter(Collision other)
        {
            Debugger.DebugLog("Collided with " + other.gameObject.name);

            if (other.gameObject.CompareTag("Ride"))
            {
                _characterRigidbody.constraints = RigidbodyConstraints.None;
            }
        }
    }
}