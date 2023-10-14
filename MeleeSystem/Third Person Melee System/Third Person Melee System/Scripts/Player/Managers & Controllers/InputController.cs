using UnityEngine;

namespace ThirdPersonMeleeSystem.Managers
{
    public class InputController : MonoBehaviour
    {
        #region Public Fields

        public static bool WalkToggle;
        public static bool SprintFlag;
        public static bool IsMoving;
        public static bool DrawWeaponFlag;
        public static bool LockOnFlag;
        public static bool TargetSwitchLeftFlag;
        public static bool TargetSwitchRightFlag;
        public static bool LightAttackFlag { get; private set; }
        public static bool HeavyAttackFlag { get; private set; }

        #endregion

        #region Private Fields

        #endregion

        #region Serialized Fields

        [SerializeField] private Camera mainCamera;

        #endregion

        #region Getters

        public Inputs PlayerInput { get; private set; }

        #endregion

        private void Awake()
        {
            PlayerInput = new Inputs();
            PlayerInput.Gameplay.Move.performed += _ => IsMoving = true;
            PlayerInput.Gameplay.Move.canceled += _ => IsMoving = false;
            PlayerInput.Gameplay.ToggleWalk.performed += _ => WalkToggle = !WalkToggle;
            PlayerInput.Gameplay.Sprint.performed += _ => SprintFlag = true;
            PlayerInput.Gameplay.Sprint.canceled += _ => SprintFlag = false;
        }

        private void OnEnable()
        {
            PlayerInput.Enable();
        }

        private void OnDisable()
        {
            PlayerInput.Disable();
        }

        private void Update()
        {
            DrawWeaponFlag = PlayerInput.Combat.DrawWeapon.WasPerformedThisFrame();
            LockOnFlag = PlayerInput.Combat.LockOn.WasPerformedThisFrame();
            TargetSwitchLeftFlag = PlayerInput.Combat.TargetSwitchLeft.WasPerformedThisFrame();
            TargetSwitchRightFlag = PlayerInput.Combat.TargetSwitchRIght.WasPerformedThisFrame();
            HandleAttackInput();
        }

        private void HandleAttackInput()
        {
            if (PlayerInput.Combat.AttackModifier.IsPressed() && !IsMoving)
            {
                HeavyAttackFlag = PlayerInput.Combat.HeavyAttack.WasPerformedThisFrame();
            }
            else
            {
                LightAttackFlag = PlayerInput.Combat.LightAttack.WasPerformedThisFrame();
            }
        }

        public Vector2 GetMovementInput()
        {
            return PlayerInput.Gameplay.Move.ReadValue<Vector2>();
        }

        public Vector3 GetMovementDirection()
        {
            Vector3 forward = mainCamera.transform.forward;
            forward.y = 0;
            forward = forward.normalized;
            return GetMovementInput().x * mainCamera.transform.right + GetMovementInput().y * forward;
        }

        public Vector2 GetLookInput()
        {
            return PlayerInput.Gameplay.Look.ReadValue<Vector2>();
        }
    }
}
