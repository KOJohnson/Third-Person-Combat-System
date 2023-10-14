using ThirdPersonMeleeSystem.Managers;
using UnityEngine;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class StateMachineController : MonoBehaviour
    {
        #region StateMachine

        public StateMachine PlayerStateMachine { get; private set; }
        private StateFactory PlayerStateFactory;

        #endregion
    
        #region Public Fields
        #endregion
    
        #region Private Fields
        #endregion
    
        #region Serialized Fields

        [SerializeField] private ThirdPersonController thirdPersonController;
        [SerializeField] private PlayerAnimationManager animationManager;
        [SerializeField] private InputController inputController;
        [SerializeField] private WeaponManager weaponManager;
        [SerializeField] private CameraController cameraController;
        
        #endregion

        #region Getters

        public ThirdPersonController ThirdPersonController => thirdPersonController;
        public PlayerAnimationManager AnimationManager => animationManager;
        public InputController InputController => inputController;
        public WeaponManager WeaponManager => weaponManager;
        public CameraController CameraController => cameraController;

        #endregion
    
        #region Debug

        [SerializeField] private bool debugStateMachine;
        [SerializeField] private int debugFontSize;

        #endregion

        private void Start()
        {
            PlayerStateMachine = new StateMachine();
            PlayerStateFactory = new StateFactory(this);
            PlayerStateMachine.Initialise(PlayerStateFactory.IdleState());
        }

        private void Update()
        {
            PlayerStateMachine.currentState.Tick(Time.deltaTime);
            PlayerStateMachine.currentState.CheckSwitchState();
        }

        private void OnGUI()
        {
            if (!debugStateMachine) return;
            GUI.skin.label.fontSize = debugFontSize;
            GUI.Label(new Rect(10,10,400,50), PlayerStateMachine.currentState.ToString());
        }
    }
}
