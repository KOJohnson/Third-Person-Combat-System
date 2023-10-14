using UnityEngine;
using UnityEngine.Events;
using ThirdPersonMeleeSystem.Interfaces;
using ThirdPersonMeleeSystem.Managers;
using ThirdPersonMeleeSystem.ScriptableObjects;
using ThirdPersonMeleeSystem.Structs;

namespace ThirdPersonMeleeSystem
{
    [RequireComponent(typeof(HealthComponent))]
    public class DamageComponent : MonoBehaviour,IDamageable
    {
        #region Public Fields
        
        
        #endregion
    
        #region Private Fields

        #endregion
    
        #region Serialized Fields
    
        [SerializeField] private AnimationManager animationManager;
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private HitReactionAnimation hitReactionData;
    
        [SerializeField] private UnityEvent OnTakeDamageEvent;
    
        #endregion
    
        #region Getters

        
        
        #endregion

        private void Start()
        {
        }

        public void TakeDamage(Vector3 attackerPos, int damage, AttackType attackType)
        {
            if (healthComponent) healthComponent.TakeDamage(damage);
            if (animationManager) animationManager.PlayAction(PlayHitReaction(attackerPos));
            OnTakeDamageEvent?.Invoke();
        }

        private AnimationData PlayHitReaction(Vector3 attacker)
        {
            if (GetRelativePosition(attacker).z > 0)
            {
                return hitReactionData.hitFrontReactions[0];
            }
            else
            {
                return hitReactionData.hitBackReactions[0];
            }
        }

        private Vector3 GetRelativePosition(Vector3 attacker)
        {
            return transform.InverseTransformPoint(attacker);
        }
    
    }
}

