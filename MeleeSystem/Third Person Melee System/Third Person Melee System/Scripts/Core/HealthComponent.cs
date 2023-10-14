using ThirdPersonMeleeSystem.ScriptableObjects;
using UnityEngine;

namespace ThirdPersonMeleeSystem
{
    public class HealthComponent : MonoBehaviour
    {
        #region Public Fields
        
        
        #endregion
    
        #region Private Fields

        private int _currentHealth;    
    
        #endregion
    
        #region Serialized Fields

        [SerializeField] private HealthStatPreset _healthStatPreset;
    
        #endregion
    
        #region Getters
        #endregion

        private void Start()
        {
            _currentHealth = _healthStatPreset.GetMaxHealth();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            Debug.Log($"Hit for: {damage} damage!");
        }
    }
}

