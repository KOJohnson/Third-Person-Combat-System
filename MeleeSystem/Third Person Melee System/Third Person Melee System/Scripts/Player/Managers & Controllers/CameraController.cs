using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace ThirdPersonMeleeSystem.Managers
{
    public class CameraController : MonoBehaviour
    {
        #region Public Fields
    
        #endregion
    
        #region Private Fields
    
        private float _targetPitch;
        private float _targetYaw;
        private List<LockOnTarget> _availableTargets = new();

        private LockOnTarget _nearestLockOnTarget;
        private LockOnTarget _leftLockOnTarget;
        private LockOnTarget _rightLockOnTarget;

        #endregion
    
        #region Serialized Fields

        [Header("Refs")]
        [SerializeField] private InputController inputController;
        [SerializeField] private Transform cameraHolder;

        [Header("Free Look Camera")] 
        [SerializeField] private float mouseSensitivity = 5f;
        [SerializeField] private float minClamp;
        [SerializeField] private float maxClamp;

        [Header("Lock On Camera")] 
        [SerializeField] private float lookAtSpeed = 0.3f;
        [SerializeField] private float maximumLockOnDistance;
        [SerializeField] private float minInViewDot;
        [SerializeField] private bool autoLockOnDefeat;
    
        #endregion
    
        #region Getters
    
        public bool LockedOnTarget { get; private set; }
        public LockOnTarget CurrentLockOnTarget { get; private set; }

        #endregion

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            HandleTargetLockOn();
            TrackTargetDistance();
        }

        private void LateUpdate()
        {
            if (LockedOnTarget)
            {
                CameraLookAt(CurrentLockOnTarget.LockOnPoint());
            }
            else
            {
                FreeLookCamera();
            }
        }

        private void FreeLookCamera()
        {
            _targetPitch += inputController.GetLookInput().y * (mouseSensitivity * Time.deltaTime);
            _targetYaw += inputController.GetLookInput().x * (mouseSensitivity * Time.deltaTime);
        
            _targetPitch = Mathf.Clamp(_targetPitch, minClamp, maxClamp);
            _targetYaw = Mathf.Clamp(_targetYaw, Single.MinValue, Single.MaxValue);
        
            cameraHolder.rotation = Quaternion.Euler(_targetPitch, _targetYaw, 0f);
        }

        private void CameraLookAt(Vector3 lookAt)
        {
            cameraHolder.DOLookAt(lookAt, lookAtSpeed, AxisConstraint.Y);
            _targetPitch = cameraHolder.eulerAngles.x;
            _targetYaw = cameraHolder.eulerAngles.y;
        }
    
        private void HandleTargetLockOn()
        {
            if (InputController.LockOnFlag && !LockedOnTarget)
            {
                HandleLockOn();

                if (_nearestLockOnTarget != null)
                {
                    CurrentLockOnTarget = _nearestLockOnTarget;
                    LockedOnTarget = true;
                }
            }
            else if (InputController.LockOnFlag && LockedOnTarget)
            {
                ClearLockOn();
            }

            if (LockedOnTarget && InputController.TargetSwitchLeftFlag)
            {
                HandleLockOn();

                if (_leftLockOnTarget != null)
                {
                    CurrentLockOnTarget = _leftLockOnTarget;
                }
            }

            if (LockedOnTarget && InputController.TargetSwitchRightFlag)
            {
                HandleLockOn();

                if (_rightLockOnTarget != null)
                {
                    CurrentLockOnTarget = _rightLockOnTarget;
                }
            }
        }
    
        private void HandleLockOn()
        {
            float shortestDistance = Mathf.Infinity;
            float shortestDistanceOfTargetLeft = -Mathf.Infinity;
            float shortestDistanceOfTargetRight = Mathf.Infinity;

            Collider[] colliders = Physics.OverlapSphere(transform.position, maximumLockOnDistance);

            for (int i = 0; i < colliders.Length; i++)
            {
                LockOnTarget target = colliders[i].GetComponent<LockOnTarget>();

                if (target != null)
                {
                    float distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);

                    if (distanceFromTarget < maximumLockOnDistance && !_availableTargets.Contains(target))
                    {
                        _availableTargets.Add(target);
                    }
                }
            }

            for (int k = 0; k < _availableTargets.Count; k++)
            {
                float distanceFromTarget = Vector3.Distance(transform.position, _availableTargets[k].transform.position);

                if (distanceFromTarget < shortestDistance)
                {
                    shortestDistance = distanceFromTarget;
                    _nearestLockOnTarget = _availableTargets[k];
                }

                if (LockedOnTarget)
                {
                    Vector3 relativeEnemyPosition = transform.InverseTransformPoint(_availableTargets[k].transform.position);
                    float distanceFromLeftTarget = relativeEnemyPosition.x;
                    float distanceFromRightTarget = relativeEnemyPosition.x;
                
                    if (relativeEnemyPosition.x <= 0 && distanceFromLeftTarget > shortestDistanceOfTargetLeft && _availableTargets[k] != CurrentLockOnTarget)
                    {
                        shortestDistanceOfTargetLeft = distanceFromLeftTarget;
                        _leftLockOnTarget = _availableTargets[k];
                    }
                    else if (relativeEnemyPosition.x >= 0 && distanceFromRightTarget < shortestDistanceOfTargetRight && _availableTargets[k] != CurrentLockOnTarget)
                    {
                        shortestDistanceOfTargetRight = distanceFromRightTarget;
                        _rightLockOnTarget = _availableTargets[k];
                    }
                }
            }
        }
    
        private void HandleLockOnDefeat()
        {
            if (autoLockOnDefeat)
            {
                ClearLockOn();
                HandleLockOn();
            }
            else
            {
                ClearLockOn();
            }
        }
        
        private void TrackTargetDistance()
        {
            if (CurrentLockOnTarget == null) return;
            if (!(Vector3.Distance(transform.position, CurrentLockOnTarget.transform.position) > maximumLockOnDistance)) return;
            ClearLockOn();
        }
    
        public void ClearLockOn()
        {
            LockedOnTarget = false;
            _availableTargets.Clear();
            CurrentLockOnTarget = null;
            _nearestLockOnTarget = null;
            _leftLockOnTarget = null;
            _rightLockOnTarget = null;
        }
    }
}