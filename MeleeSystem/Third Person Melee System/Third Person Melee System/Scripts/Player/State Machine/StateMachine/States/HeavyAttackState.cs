
namespace ThirdPersonMeleeSystem.StateMachine
{
    public class HeavyAttackState : BaseAttackState
    {
        public HeavyAttackState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }

        protected override void HandleAttackOnStateEnter()
        {
            HandleAttackCombo(_heavyAttackIndex, this);
        }
    }
}