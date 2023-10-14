using ThirdPersonMeleeSystem.Managers;
using ThirdPersonMeleeSystem.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public abstract class BaseAttackState : BaseState
    {
        public BaseAttackState(StateMachineController stateMachineController, StateFactory stateFactory) : base(stateMachineController, stateFactory)
        {
        }
        
        protected int _lightAttackIndex;
        protected int _heavyAttackIndex;

        private Vector2 _inputDirection;
        private Quaternion _startRotation;

        private float _cameraY;
        private float _timeElapsed;
        private float _lerpDuration = 0.3f;

        public override void EnterState()
        {
            _stateMachineController.AnimationManager.SetAnimationBlend(0f);
            HandleAttackOnStateEnter();
            _timeElapsed = 0f;
            _cameraY = _stateMachineController.ThirdPersonController.MainCam.transform.eulerAngles.y;
            _inputDirection = _stateMachineController.InputController.GetMovementInput();
            _startRotation = _stateMachineController.transform.rotation;
        }

        protected override void ExitState()
        {
            WeaponManager.Instance.PlayerWeaponEvents.OnEnableCombo(false);
        }
        
        public override void Tick(float delta)
        {
            HandleRotation();
        }

        public override void CheckSwitchState()
        {
            if (!PlayerAnimationManager.Instance.IsInteracting)
            {
                ResetAttackIndex();
                
                if (!_stateMachineController.ThirdPersonController.PlayerGrounded)
                {
                    ChangeState(_stateFactory.InAirState());
                }
                else
                {
                    ChangeState(_stateFactory.IdleState()); 
                }
            }

            if (InputController.HeavyAttackFlag && WeaponManager.Instance.CanCombo)
            {
                ChangeState(_stateFactory.HeavyAttackState());
            }
            
            if (InputController.LightAttackFlag && WeaponManager.Instance.CanCombo)
            {
                ChangeState(_stateFactory.LightAttackState());
            }
        }

        protected abstract void HandleAttackOnStateEnter();

        private void HandleRotation()
        {
            if (_stateMachineController.CameraController.LockedOnTarget)
            {
                RotateToTarget(_stateMachineController.CameraController.CurrentLockOnTarget.LockOnPoint());
            }
            else
            {
                _stateMachineController.ThirdPersonController.RotateToMovementDirection(_inputDirection, _cameraY);
            }
        }

        private void RotateToTarget(Vector3 target)
        {
            Vector3 direction = (target - _stateMachineController.transform.position).normalized;
            direction.y = 0;
            
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        
            if (_timeElapsed < _lerpDuration)
            {
                _stateMachineController.transform.rotation =
                    Quaternion.Slerp(_startRotation, rotation, _timeElapsed / _lerpDuration);
                _timeElapsed += Time.deltaTime;
            }
            else
            {
                _stateMachineController.transform.rotation = rotation;
            }
        }

        protected void HandleAttackCombo(int index, BaseAttackState attackState)
        {
            if (attackState.GetType() == typeof(LightAttackState))
            {
                if (WeaponManager.Instance.GetCurrentWeapon().lightAttacks.Length == 0) return;
                PlayAttackAnimation(WeaponManager.Instance.GetCurrentWeapon().lightAttacks[index]);
                _lightAttackIndex = (_lightAttackIndex + 1) % WeaponManager.Instance.GetCurrentWeapon().lightAttacks.Length;
            }
            if (attackState.GetType() == typeof(HeavyAttackState))
            {
                if (WeaponManager.Instance.GetCurrentWeapon().heavyAttacks.Length == 0) return;
                PlayAttackAnimation(WeaponManager.Instance.GetCurrentWeapon().heavyAttacks[index]);
                _heavyAttackIndex = (_heavyAttackIndex + 1) % WeaponManager.Instance.GetCurrentWeapon().heavyAttacks.Length;
            }
        }

        protected void PlayAttackAnimation(AttackData attackData)
        {
            if (attackData == null) return;
            if (attackData.attackAnimationData.attackAnimation == null) return;
            _stateMachineController.WeaponManager.SetLastAttack(attackData.attackAnimationData);
            _stateMachineController.AnimationManager.PlayAction(attackData.attackAnimationData.attackAnimation);
        }

        private void ResetAttackIndex()
        {
            _lightAttackIndex = 0;
            _heavyAttackIndex = 0;
        }
    }
}