using System.Collections;
using Animancer;
using ThirdPersonMeleeSystem.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonMeleeSystem.Managers
{
    public class ThirdPersonController : MonoBehaviour
    {
        #region Public Fields

        public bool UseRootMotion;
        
        #endregion

        #region Private Fields
        
        private Vector3 _playerVelocity;
        private float _speed;

        private float _targetRotation;
        private float _rotationVelocity;

        #endregion

        #region Serialized Fields

        [Header("Refs")] 
        [SerializeField] private AnimancerComponent animancerComponent;
        [SerializeField] private PlayerAnimationManager animationManager;
        [SerializeField] private InputController inputController;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private WeaponManager weaponManager;

        [Header("Gravity")] [SerializeField] private float gravity = -9.81f;

        [Header("Ground Check")] 
        [SerializeField] private bool grounded;
        [SerializeField] private float sphereCastRadius;
        [SerializeField] private float sphereCastDistance;
        [SerializeField] private float yOffset;
        [SerializeField] private float slopeRayLength;
        [SerializeField] private LayerMask whatIsGround;

        [Header("Animation")] 
        [SerializeField] private LocomotionAsset locomotionAsset;

        [Header("Movement Speed")]
        [SerializeField] private float walkSpeed = 3f;
        [SerializeField] private float jogSpeed = 5f;
        [SerializeField] private float sprintSpeed = 7f;
        [SerializeField] private float airSpeed;

        [Header("Rotation")]
        [SerializeField] private float rotationSmoothTime;
        [SerializeField] private float lockOnRotationSpeed;

        [Header("Jump")] 
        [SerializeField] private bool enableDoubleJump;
        [SerializeField] private float jumpVelocity;
        [SerializeField] private int jumpCount = 2;

        #endregion

        #region Getters
        
        public Camera MainCam { get; private set; }
        public PlayerAnimationManager AnimationManager => animationManager;
        public CharacterController CharacterController => characterController;
        public InputController InputController => inputController;
        public float CharacterHeight => characterController.height;
        public float YSpeed { get; set; }
        public float WalkSpeed => walkSpeed;
        public float JogSpeed => jogSpeed;
        public float SprintSpeed => sprintSpeed;
        public float AirSpeed => airSpeed;
        public bool EnableDoubleJump => enableDoubleJump;
        public bool PlayerGrounded => grounded;
        public int JumpCount => jumpCount;

        #endregion

        private void OnEnable()
        {
            weaponManager.PlayerWeaponEvents.JumpEvent += Jump;
        }

        private void OnDisable()
        {
            weaponManager.PlayerWeaponEvents.JumpEvent -= Jump;
        }

        private void Start()
        {
            MainCam = Camera.main;
        }

        private void Update()
        {
            GroundCheck();
            HandleGravity();
            Rotate();
        }

        private void OnAnimatorMove()
        {
            Vector3 animatorVelocity = AdjustVelocityToSlope(animancerComponent.Animator.deltaPosition);
            Vector3 airVelocity = inputController.GetMovementDirection() * airSpeed * Time.deltaTime;
            _playerVelocity = grounded ? animatorVelocity : airVelocity;
            _playerVelocity.y += YSpeed * Time.deltaTime;
            characterController.Move(_playerVelocity);
        }
        
        private void Move(float deltaTime)
        {
            if (UseRootMotion) return;
            Vector3 groundedVelocity = AdjustVelocityToSlope(inputController.GetMovementDirection() * jogSpeed);
            Vector3 inAirVelocity = inputController.GetMovementDirection() * airSpeed;
            _playerVelocity = grounded ? groundedVelocity : inAirVelocity;
            _playerVelocity.y += YSpeed;
            characterController.Move(_playerVelocity * deltaTime);
        }

        private void Rotate()
        {
            if (AnimationManager.IsInteracting) return;
            RotateToMovementDirection();
        }
        
        public void RotateToMovementDirection()
        {
            if (inputController.GetMovementInput() == Vector2.zero) return;
            Vector2 input = inputController.GetMovementInput();
            _targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + MainCam.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0f,rotation,0f);
        }

        public void RotateToMovementDirection(Vector2 input, float cameraY)
        {
            if (input == Vector2.zero) return;
            _targetRotation = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cameraY;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0f,rotation,0f);
        }

        public void LookAtTarget(Vector3 target)
        {
            Vector3 direction = (target - transform.position).normalized;
            direction.y = 0;
            
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, lockOnRotationSpeed * Time.deltaTime);
        }

        public void LookAtTarget(Vector3 target, float duration)
        {
            StartCoroutine(RotateToTarget(target, duration));
        }
        
        private IEnumerator RotateToTarget(Vector3 target, float duration)
        {
            Quaternion startRotation = transform.rotation;
            float timeElapsed = 0f;
            
            Vector3 direction = (target - transform.position).normalized;
            direction.y = 0;
            
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            while (timeElapsed < duration)
            {
                transform.rotation = Quaternion.Slerp(startRotation, rotation, timeElapsed / duration);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }

        public void SetMovementSpeed(float speed)
        {
            _speed = speed;
        }

        private void GroundCheck()
        {
            Ray groundRay = new Ray(transform.position + new Vector3(0f, yOffset, 0f), Vector3.down);
            grounded = Physics.SphereCast(groundRay, sphereCastRadius, sphereCastDistance, whatIsGround);
        }

        private void HandleGravity()
        {
            YSpeed = grounded && YSpeed < 0 ? -1.0f : YSpeed += gravity * Time.deltaTime;
        }

        public LocomotionAsset GetLocomotionAsset()
        {
            return locomotionAsset;
        }

        public void Jump(float jumpForce)
        {
            jumpCount--;
            YSpeed = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        public void ResetJumpCount()
        {
            jumpCount = 2;
        }

        private Vector3 AdjustVelocityToSlope(Vector3 velocity)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, slopeRayLength, whatIsGround))
            {
                Quaternion slopeRotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                Vector3 adjustedVelocity = slopeRotation * velocity;

                if (adjustedVelocity.y < 0)
                {
                    return adjustedVelocity;
                }
            }
            return velocity;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = grounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position + new Vector3(0f, yOffset, 0f), sphereCastRadius);
        }
    }
}
