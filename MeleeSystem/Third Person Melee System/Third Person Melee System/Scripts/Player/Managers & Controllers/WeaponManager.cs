using ThirdPersonMeleeSystem.ScriptableObjects;
using ThirdPersonMeleeSystem.Structs;
using UnityEngine;
using ThirdPersonMeleeSystem.Weapons;

namespace ThirdPersonMeleeSystem.Managers
{
    public class WeaponManager : MonoBehaviour
    {
        #region Public Fields

        public static WeaponManager Instance;

        #endregion
    
        #region Private Fields

        #endregion
    
        #region Serialized Fields
        
        [SerializeField] private MeleeWeapon currentWeapon;
        [SerializeField] private WeaponEvents playerWeaponEvents;

        #endregion
    
        #region Getters

        public WeaponEvents PlayerWeaponEvents => playerWeaponEvents;
        public bool IsWeaponDrawn { get; private set; }
        public bool CanCombo { get; private set; }
        public AttackAnimationData LastAttack { get; private set; }
        
        #endregion

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            if (IsValidWeapon())
            {
                currentWeapon.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            playerWeaponEvents.ToggleCanCombo += ToggleCanCombo;
        }

        private void OnDisable()
        {
            playerWeaponEvents.ToggleCanCombo -= ToggleCanCombo;
        }

        public MeleeWeapon GetCurrentWeapon()
        {
            return currentWeapon;
        }

        public void EquipWeapon()
        {
            PlayerAnimationManager.Instance.PlayAction(currentWeapon.equipAnimation);
            currentWeapon.gameObject.SetActive(true);
            SetIsWeaponDrawn(true);
        }
        
        public void SheatheWeapon()
        {
            PlayerAnimationManager.Instance.PlayAction(currentWeapon.sheatheAnimation);
            currentWeapon.gameObject.SetActive(false);
            SetIsWeaponDrawn(false);
        }

        public bool IsValidWeapon()
        {
            return currentWeapon != null;
        }

        public void SetCurrentWeapon(MeleeWeapon newWeapon)
        {
            if (IsValidWeapon()) currentWeapon.gameObject.SetActive(false);
            currentWeapon = newWeapon;
        }

        public void SetIsWeaponDrawn(bool status)
        {
            IsWeaponDrawn = status;
        }

        public void SetLastAttack(AttackAnimationData lastAttack)
        {
            LastAttack = lastAttack;
        }

        private void ToggleCanCombo(bool toggle)
        {
            CanCombo = toggle;
        }

    }
}
