using ThirdPersonMeleeSystem.Managers;
using ThirdPersonMeleeSystem.ScriptableObjects;
using ThirdPersonMeleeSystem.Structs;
using UnityEngine;

namespace ThirdPersonMeleeSystem.Weapons
{
    [RequireComponent(typeof(WeaponDamageComponent))]
    public class MeleeWeapon : MonoBehaviour
    {
        #region Private Fields
        
        private WeaponDamageComponent _weaponDamageComponent;
        
        #endregion
        
        #region Public Fields

        [Header("Stats")] 
        [SerializeField]private int damage;
        
        [Header("Attack Animations")]
        public AttackData[] lightAttacks;
        public AttackData[] heavyAttacks;
        public AttackData sprintAttack;

        [Header("Equip Animations")] 
        public AnimationData equipAnimation; 
        public AnimationData sheatheAnimation;
        
        #endregion

        #region Serialized Fields

        [Header("Locomotion Animations")] 
        [SerializeField] private CombatLocomotionAsset locomotionAsset;

        #endregion
    
        #region Getters

        public CombatLocomotionAsset LocomotionAsset => locomotionAsset;
        public WeaponManager WeaponManager { get; private set; }

        #endregion

        private void OnValidate()
        {
            InitializeComponents();
            SetupAttacks();
        }

        private void OnEnable()
        {
           InitializeWeapon();
        }

        private void OnDisable()
        {
            DeconstructWeapon();
        }

        #region Setup

        private void SetupAttacks()
        {
            if (lightAttacks.Length > 0)
            {
                foreach (AttackData attack in lightAttacks)
                {
                    if (attack == null) continue;
                    attack.attackAnimationData.attackAnimation.IsInteracting = true;
                    attack.attackAnimationData.attackType = AttackType.LightAttack;
                }
            }

            if (heavyAttacks.Length > 0)
            {
                foreach (AttackData attack in heavyAttacks)
                {
                    if (attack == null) continue;
                    attack.attackAnimationData.attackAnimation.IsInteracting = true;
                    attack.attackAnimationData.attackType = AttackType.HeavyAttack;
                }
            }
        }
        private void InitializeComponents()
        {
            if (!_weaponDamageComponent)
            {
                _weaponDamageComponent = GetComponent<WeaponDamageComponent>();
            }

            if (!WeaponManager)
            {
                WeaponManager = transform.root.GetComponent<WeaponManager>();
            }
        }
        private void InitializeWeapon()
        {
            if (WeaponManager)
            {
                WeaponManager.PlayerWeaponEvents.ToggleDamageComponent += ToggleDamageComponent;
                ToggleDamageComponent(false);
            }
        }
        
        private void DeconstructWeapon()
        {
            WeaponManager.PlayerWeaponEvents.ToggleDamageComponent -= ToggleDamageComponent;
            ToggleDamageComponent(false);
        }

        #endregion

        private void ToggleDamageComponent(bool toggle)
        {
            _weaponDamageComponent.enabled = toggle;
        }

        public int GetWeaponDamage()
        {
            return WeaponManager.LastAttack.OverrideDamage ? WeaponManager.LastAttack.damageOverride : damage;
        }

        public AttackType GetAttackType()
        {
            return WeaponManager.LastAttack.attackType;
        }
        
    }
}
