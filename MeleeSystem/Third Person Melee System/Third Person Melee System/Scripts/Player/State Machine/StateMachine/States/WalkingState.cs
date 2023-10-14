namespace ThirdPersonMeleeSystem.StateMachine
{
    public class WalkingState : BaseLocomotion
    {
        public WalkingState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }


        public override void Tick(float delta)
        {
            base.Tick(delta);
            PlayAnimationBlendTree(walkBlendTarget);
        }

        public override void CheckSwitchState()
        {
            base.CheckSwitchState();
            
        }
    } 
}

