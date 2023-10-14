using System.Collections;
using Animancer;
using UnityEngine;

namespace ThirdPersonMeleeSystem
{
    public class HitStop
    {
        private AnimancerComponent _animancerComponent;
        public bool IsWaiting { get; private set; }
        
        public HitStop(AnimancerComponent animancerComponent)
        {
            _animancerComponent = animancerComponent;
        }

        public IEnumerator FreezeAnimator(float duration)
        {
            IsWaiting = true;
            _animancerComponent.Playable.Speed = 0;
            yield return new WaitForSecondsRealtime(duration);
            IsWaiting = false;
            _animancerComponent.Playable.Speed = 1;
        } 
    }
}