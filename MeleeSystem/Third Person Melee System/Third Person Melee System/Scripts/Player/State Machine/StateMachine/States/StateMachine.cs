namespace ThirdPersonMeleeSystem.StateMachine
{
    public class StateMachine
    {
        public BaseState currentState;
        public BaseState lastState;

        public void Initialise(BaseState startingState)
        {
            currentState = startingState;
            startingState.EnterState();
        }
    }
}


