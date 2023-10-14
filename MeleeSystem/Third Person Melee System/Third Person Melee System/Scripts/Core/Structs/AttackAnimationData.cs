using System;
using UnityEngine;

namespace ThirdPersonMeleeSystem.Structs
{
    public enum AttackType
    {
        LightAttack,
        HeavyAttack
    }
    
    [Serializable]
    public struct AttackAnimationData
    {
        public AnimationData attackAnimation;
        public AttackType attackType;
        
        [Header("Overrides")]
        [Space]public bool OverrideDamage;
        public int damageOverride;
        
        [Space] public bool OverrideAnimation;
        public AnimationData animationOverride;
    }
}