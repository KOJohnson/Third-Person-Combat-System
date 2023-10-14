using Animancer;
using ThirdPersonMeleeSystem.Structs;
using UnityEngine;

namespace ThirdPersonMeleeSystem.Managers
{
    public class AnimationManager : MonoBehaviour
    {
        #region Public Fields
        
        
        #endregion
    
        #region Private Fields

        protected AnimancerLayer _locomotionLayer;
        protected AnimancerLayer _actionLayer;
        protected float _animBlendRef;
    
        #endregion
    
        #region Serialized Fields

        [SerializeField] private AnimancerComponent animancerComponent;
        [SerializeField] private float animationSmoothTime = 0.15f;
        [SerializeField] private float layerFadeDuration;
    
        #endregion
    
        #region Getters
        
        public bool IsInteracting { get; private set; }
        public bool IsAnimationSticky { get; private set; }
        public float AnimationBlend { get; private set; }
        
        #endregion

        protected virtual void Start()
        {
            _locomotionLayer = animancerComponent.Layers[0];
            _actionLayer = animancerComponent.Layers[1];
        }

        public void PlayMixer(LinearMixerTransitionAsset.UnShared mixer, float transitionParameter)
        {
            if (mixer == null) return;
            _locomotionLayer.Play(mixer);
            mixer.State.Parameter = transitionParameter;
        }

        public void Play(AnimationData motion)
        {
            if (motion.Clip == null) return;
            IsInteracting = motion.IsInteracting;
            AnimancerState state = _locomotionLayer.Play(motion);
            state.Events.OnEnd += () => IsInteracting = false;
        }

        public void PlayAction(AnimationData motion)
        {
            if (motion.Clip == null) return;
            IsInteracting = motion.IsInteracting;
            AnimancerState state = _actionLayer.Play(motion);
            state.Events.OnEnd += OnActionEnd;
        }

        public float SmoothAnimationBlend(float targetBlend)
        {
            return AnimationBlend = Mathf.SmoothDamp(AnimationBlend, targetBlend, ref _animBlendRef, animationSmoothTime);
        }
        
        public void SetAnimationBlend(float targetBlend)
        {
            AnimationBlend = targetBlend;
        }
        
        protected void OnActionEnd()
        {
            IsInteracting = false;
            IsAnimationSticky = false;
            _actionLayer.StartFade(0f, layerFadeDuration);
        }
    }
}
