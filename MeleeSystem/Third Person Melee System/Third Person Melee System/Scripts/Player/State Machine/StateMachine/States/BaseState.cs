namespace ThirdPersonMeleeSystem.StateMachine
{
    public abstract class BaseState
    {
        protected readonly StateMachineController _stateMachineController;
        protected readonly StateFactory _stateFactory;

        protected BaseState(StateMachineController stateMachineController, StateFactory stateFactory)
        {
            _stateMachineController = stateMachineController;
            _stateFactory = stateFactory;
        }

        public abstract void EnterState();
        public abstract void Tick(float delta);
        protected abstract void ExitState();
        public abstract void CheckSwitchState();

        protected void ChangeState(BaseState newState)
        {
            _stateMachineController.PlayerStateMachine.lastState = this;
            ExitState();
            
            newState.EnterState();
            _stateMachineController.PlayerStateMachine.currentState = newState;
        }
    }
}
