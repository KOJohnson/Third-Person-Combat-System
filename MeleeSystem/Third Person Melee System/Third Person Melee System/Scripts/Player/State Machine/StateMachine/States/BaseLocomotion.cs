using ThirdPersonMeleeSystem.Managers;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class BaseLocomotion : BaseState
    {
        public BaseLocomotion(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }
        
        protected const int idleBlendTarget = 0;
        protected const int walkBlendTarget = 1;
        protected const int jogBlendTarget = 2;
        protected const int runBlendTarget = 3;


        public override void EnterState()
        {
            
        }

        public override void Tick(float delta)
        {
            HandleWeaponEquip();
        }

        protected override void ExitState()
        {
        }

        public override void CheckSwitchState()
        {
            if (_stateMachineController.PlayerStateMachine.currentState is not IdleState)
            {
                if (!InputController.IsMoving)
                {
                    ChangeState(_stateFactory.IdleState());
                }
            }

            if (_stateMachineController.PlayerStateMachine.currentState is not WalkingState)
            {
                if (InputController.WalkToggle && InputController.IsMoving)
                {
                    ChangeState(_stateFactory.WalkingState());
                }
            }

            if (_stateMachineController.PlayerStateMachine.currentState is not JoggingState)
            {
                if (!InputController.WalkToggle && !InputController.SprintFlag && InputController.IsMoving)
                {
                    ChangeState(_stateFactory.JoggingState());
                }
            }

            if (_stateMachineController.PlayerStateMachine.currentState is not RunningState)
            {
                if (InputController.SprintFlag && InputController.IsMoving)
                {
                    ChangeState(_stateFactory.RunningState());
                }
            }

            if (_stateMachineController.WeaponManager.IsWeaponDrawn && !PlayerAnimationManager.Instance.IsInteracting)
            {
                if (InputController.HeavyAttackFlag)
                {
                    ChangeState(_stateFactory.HeavyAttackState());
                }

                if (InputController.LightAttackFlag)
                {
                    if (!InputController.IsMoving || !InputController.SprintFlag)
                    {
                        ChangeState(_stateFactory.LightAttackState());
                    }
                    else
                    {
                        ChangeState(_stateFactory.SprintAttackState());
                    }
                }
            }
        }

        private void PlayStopAnimation()
        {
            PlayerAnimationManager.Instance.SetAnimationBlend(0f);
            switch (_stateMachineController.PlayerStateMachine.currentState)
            {
                case WalkingState: 
                    PlayerAnimationManager.Instance.Play(_stateMachineController.ThirdPersonController.GetLocomotionAsset().walkStop);
                    break;
                case JoggingState:
                    PlayerAnimationManager.Instance.Play(_stateMachineController.ThirdPersonController.GetLocomotionAsset().jogStop);
                    break;
                case RunningState:
                    PlayerAnimationManager.Instance.Play(_stateMachineController.ThirdPersonController.GetLocomotionAsset().runStop);
                    break;
            }
        }

        private void HandleWeaponEquip()
        {
            if (!WeaponManager.Instance.IsWeaponDrawn)
            {
                if (!PlayerAnimationManager.Instance.IsInteracting && InputController.DrawWeaponFlag && WeaponManager.Instance.IsValidWeapon())
                {
                    WeaponManager.Instance.EquipWeapon();
                }
            }
            else
            {
                if (!PlayerAnimationManager.Instance.IsInteracting && InputController.DrawWeaponFlag && WeaponManager.Instance.IsValidWeapon())
                {
                    WeaponManager.Instance.SheatheWeapon();
                }
            }
        }

        protected void PlayAnimationBlendTree(float targetBlend)
        {
            var combatMixer = _stateMachineController.WeaponManager.GetCurrentWeapon().LocomotionAsset.GetLocomotionMixer();
            var outOfCombatMixer = _stateMachineController.ThirdPersonController.GetLocomotionAsset().GetLocomotionMixer();
            var locomotionMixer = _stateMachineController.WeaponManager.IsWeaponDrawn ? combatMixer : outOfCombatMixer;

            if (PlayerAnimationManager.Instance.IsInteracting)return;
            _stateMachineController.AnimationManager.PlayMixer(locomotionMixer, _stateMachineController.AnimationManager.SmoothAnimationBlend(targetBlend));
        }
    }
}