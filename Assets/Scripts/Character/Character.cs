using UnityEngine;

namespace Meltdown
{
    public class Character : MonoBehaviour, IInitializer
    {
        [Header("References:")]
        [SerializeField] protected GameObject _characterPrefab;
        
        [Header("Movement Values:")] 
        [SerializeField]                     private float _jumpForce     = 5    ;
        [SerializeField]                     private float _maxSpeed      = 5;
        
        //Controllers
        private CharacterAnimationController _characterAnimationController;
        
        //Local References
        private Rigidbody _characterRigidbody;
        private GameObject _instantiatedCharacterObject;

        //State controller
        protected IBaseStateMachine CharacterPhysicalStateMachine;
        
        //Getters
        public CharacterAnimationController GetCharacterAnimationController() => _characterAnimationController;
        public Rigidbody GetCharacterRigidbody() => _characterRigidbody;
        public GameObject GetCharacterObject() => _instantiatedCharacterObject;
        
        public float GetJumpForce() => _jumpForce;
        public float GetMaxSpeed() => _maxSpeed;
        
        
        public virtual void Initialize()
        {
            _instantiatedCharacterObject = InstantiateCharacterObject();

            Animator characterAnimator  = _instantiatedCharacterObject.GetComponent<Animator>();
            _characterRigidbody = _instantiatedCharacterObject.GetComponent<Rigidbody>();
            
            _characterAnimationController = new CharacterAnimationController(characterAnimator);

            CharacterPhysicalStateMachine = new PlayerPhysicalStateMachine(gameObject);
        }

        private void Update()
        {
            CharacterPhysicalStateMachine.GetCurrentState().LogicUpdate();
        }

        private void FixedUpdate()
        {
            CharacterPhysicalStateMachine.GetCurrentState().PhysicsUpdate();
        }

        private GameObject InstantiateCharacterObject()
        {
            return _characterPrefab == null ? null : Instantiate(_characterPrefab);
        }

    }
}