namespace ThirdPersonMeleeSystem.StateMachine
{
    public class RunningState : BaseLocomotion
    {
        public RunningState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }

        
        public override void Tick(float delta)
        {
            base.Tick(delta);
            PlayAnimationBlendTree(runBlendTarget);
        }
    }
}

