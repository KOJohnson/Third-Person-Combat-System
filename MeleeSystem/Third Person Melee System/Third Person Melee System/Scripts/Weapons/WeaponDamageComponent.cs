using System.Collections.Generic;
using Animancer;
using ThirdPersonMeleeSystem.Interfaces;
using UnityEngine;

namespace ThirdPersonMeleeSystem.Weapons
{
    [RequireComponent(typeof(Collider))]
    public class WeaponDamageComponent : MonoBehaviour
    {

        #region Private

        private HitStop _hitStop;
        private Ray _hitDetectionRay;
        private Collider _weaponCollider;
        private List<Collider> hitObjects = new List<Collider>();
        private bool _useColliderDetection;

        #endregion
        
        #region Serialized Fields
        
        [Header("Settings")]
        [SerializeField] private MeleeWeapon weapon;
        [SerializeField] private LayerMask layerMask;
        [SerializeField][Range(0, 0.5f)] private float hitStopDuration;
        
        [Header("Hit Detection")]
        [SerializeField] private Transform[] raycastPoints;
        [SerializeField] private bool useRaycastDetection;

        #endregion

        private void Awake()
        {
            _hitStop = new HitStop(transform.root.GetComponent<AnimancerComponent>());
        }

        private void OnValidate()
        {
            _useColliderDetection = !useRaycastDetection;
            
            if (_weaponCollider == null) _weaponCollider = GetComponent<Collider>();
            _weaponCollider.enabled = _useColliderDetection;
            _weaponCollider.isTrigger = true;
        }

        private void OnDisable()
        {
            hitObjects.Clear();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!enabled) return;
            if (!_useColliderDetection) return;
            if (other.CompareTag("Player")) return;
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable?.TakeDamage(transform.root.position, weapon.GetWeaponDamage(), weapon.GetAttackType());
            HitStop(hitStopDuration);
        }

        private void Update()
        {
            RaycastHitDetection();
        }

        private void HitStop(float duration)
        {
            if (_hitStop.IsWaiting)return;
            StartCoroutine(_hitStop.FreezeAnimator(duration));
        }

        public void RaycastHitDetection()
        {
            if (!useRaycastDetection) return;
            
            for (int i = 0; i < raycastPoints.Length; i++)
            {
                if (i + 1 < raycastPoints.Length)
                {
                    Vector3 direction = raycastPoints[i + 1].position - raycastPoints[i].position;
                    float rayLength = direction.magnitude;
                    direction.Normalize();

                    _hitDetectionRay.origin = raycastPoints[i].position;
                    _hitDetectionRay.direction = -direction;

                    if (Physics.Raycast(_hitDetectionRay, out RaycastHit hitInfo, rayLength, layerMask))
                    {
                        Debug.DrawRay(raycastPoints[i].position, direction * rayLength, Color.green, 3f);
                        if (hitObjects.Contains(hitInfo.collider)) return;
                        hitObjects.Add(hitInfo.collider);
                        IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                        damageable?.TakeDamage(transform.root.position, weapon.GetWeaponDamage(), weapon.GetAttackType());
                        HitStop(hitStopDuration);
                    }
                    else
                    {
                        Debug.DrawRay(raycastPoints[i].position, direction * rayLength, Color.red, 3f);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            
            for (int i = 0; i < raycastPoints.Length; i++)
            {
                Gizmos.DrawSphere(raycastPoints[i].position, 0.05f);
                
                if (i + 1 < raycastPoints.Length)
                {
                    Gizmos.DrawLine(raycastPoints[i].position, raycastPoints[i + 1].position);
                }
            }
        }
    }
}