using UnityEngine;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class JoggingState : BaseLocomotion
    {
        public JoggingState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }
        
        public override void Tick(float delta)
        {
            base.Tick(delta);
            PlayAnimationBlendTree(jogBlendTarget);
        }
    }
}