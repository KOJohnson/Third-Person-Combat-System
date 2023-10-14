namespace ThirdPersonMeleeSystem.StateMachine
{
    public class LightAttackState : BaseAttackState
    {
        public LightAttackState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }

        protected override void HandleAttackOnStateEnter()
        {
            HandleAttackCombo(_lightAttackIndex, this);
        }
    }
}