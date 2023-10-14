using ThirdPersonMeleeSystem.Managers;
using UnityEngine;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class IdleState : BaseLocomotion
    {
        public IdleState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }
        
        
        public override void Tick(float delta)
        {
            base.Tick(delta);
            PlayAnimationBlendTree(idleBlendTarget);
        }

        private void PlayStartAnimations()
        {
            if (InputController.WalkToggle)
            {
                if (InputController.IsMoving)
                {
                    Debug.Log("Play walk start");
                    PlayerAnimationManager.Instance.PlayAction(_stateMachineController.ThirdPersonController.GetLocomotionAsset().walkStart);
                }
            }
            else
            {
                if (InputController.IsMoving)
                {
                    if (InputController.SprintFlag)
                    {
                        Debug.Log("Play run start");
                        PlayerAnimationManager.Instance.PlayAction(_stateMachineController.ThirdPersonController.GetLocomotionAsset().runStart);
                    }
                    else
                    {
                        Debug.Log("Play jog start");
                        PlayerAnimationManager.Instance.PlayAction(_stateMachineController.ThirdPersonController.GetLocomotionAsset().jogStart);
                    }
                }
            }
        }
    }
}

