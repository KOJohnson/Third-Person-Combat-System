using Animancer;
using ThirdPersonMeleeSystem.Structs;
using UnityEngine;

namespace ThirdPersonMeleeSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Combat Locomotion Asset", menuName = "Scriptable Objects/Animation/CombatLocomotionAsset", order = 0)]
    public class CombatLocomotionAsset : ScriptableObject
    {
        [Header("Mixers")]
        [SerializeField] private LinearMixerTransitionAsset.UnShared locomotionMixer;
        [SerializeField] private MixerTransition2D directionalLocomotionMixer;
        
        [Header("Start Animations")]
        public AnimationData combatWalkStart;
        public AnimationData combatJogStart;
        public AnimationData combatRunStart;
        
        [Header("Stop Animations")]
        public AnimationData combatWalkStop;
        public AnimationData combatJogStop;
        public AnimationData combatRunStop;

        [Header("Jump Animations")] 
        public AnimationData combatJumpStart;
        public AnimationData combatJumpLoop;
        public AnimationData combatJumpEnd;

        public LinearMixerTransitionAsset.UnShared GetLocomotionMixer()
        {
            return locomotionMixer;
        }
        
        public MixerTransition2D GetDirectionalLocomotionMixer()
        {
            return directionalLocomotionMixer;
        }
    }
}