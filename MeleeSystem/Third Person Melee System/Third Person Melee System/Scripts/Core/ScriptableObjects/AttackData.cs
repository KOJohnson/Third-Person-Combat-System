﻿using ThirdPersonMeleeSystem.Structs;
using UnityEngine;

namespace ThirdPersonMeleeSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Attack Data", menuName = "Scriptable Objects/AttackData", order = 0)]
    public class AttackData : ScriptableObject
    {
        public AttackAnimationData attackAnimationData;
    }
}