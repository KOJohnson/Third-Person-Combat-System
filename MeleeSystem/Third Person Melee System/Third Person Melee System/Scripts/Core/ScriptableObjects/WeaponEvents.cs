using System;
using UnityEngine;

namespace ThirdPersonMeleeSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New WeaponEvent", menuName = "Scriptable Objects/WeaponEvents", order = 0)]
    public class WeaponEvents : ScriptableObject
    {
        public event Action<bool> ToggleWeaponEvent;
        public event Action<bool> ToggleCanCombo;
        public event Action<bool> ToggleDamageComponent;
        public event Action<float> JumpEvent;

        public void OnToggleWeaponEvent(bool toggle)
        {
            ToggleWeaponEvent?.Invoke(toggle);
        }

        public void OnEnableCombo(bool toggle)
        {
            ToggleCanCombo?.Invoke(toggle);
        }

        public void OnToggleDamageComponent(bool toggle)
        {
            ToggleDamageComponent?.Invoke(toggle);
        }

        public void OnJumpEvent(float jumpForce)
        {
            JumpEvent?.Invoke(jumpForce);
        }
    }
}