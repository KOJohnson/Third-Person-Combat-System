using ThirdPersonMeleeSystem.Managers;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class SprintAttackState : BaseAttackState
    {
        public SprintAttackState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }

        protected override void HandleAttackOnStateEnter()
        {
            PlayAttackAnimation(WeaponManager.Instance.GetCurrentWeapon().sprintAttack);
        }
    }
}