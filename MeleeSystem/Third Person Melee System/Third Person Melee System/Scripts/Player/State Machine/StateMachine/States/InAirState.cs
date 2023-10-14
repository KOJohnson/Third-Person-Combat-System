using ThirdPersonMeleeSystem.Managers;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class InAirState : BaseState
    {
        public InAirState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }

        public override void EnterState()
        {
            //change gravity strength for a little bit 
        }

        public override void Tick(float delta)
        {
            _stateMachineController.AnimationManager.Play(WeaponManager.Instance.IsWeaponDrawn ?
                WeaponManager.Instance.GetCurrentWeapon().LocomotionAsset.combatJumpLoop :
                _stateMachineController.ThirdPersonController.GetLocomotionAsset().jumpLoop);
        }

        protected override void ExitState()
        {
            _stateMachineController.AnimationManager.Play(WeaponManager.Instance.IsWeaponDrawn ?
                WeaponManager.Instance.GetCurrentWeapon().LocomotionAsset.combatJumpEnd :
                _stateMachineController.ThirdPersonController.GetLocomotionAsset().jumpEnd);
        }

        public override void CheckSwitchState()
        {
            if (_stateMachineController.ThirdPersonController.PlayerGrounded)
            {
                ChangeState(_stateFactory.IdleState());
            }
        }
    }
}