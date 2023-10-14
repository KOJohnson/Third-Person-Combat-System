using System.Collections.Generic;

namespace ThirdPersonMeleeSystem.StateMachine
{
    public class StateFactory
    {
        private enum _states
        {
            IDLE,
            WALK,
            JOG,
            RUN,
            LIGHTATTACK,
            HEAVYATTACK,
            SPRINTATTACK,
            INAIRSTATE
        }
        private readonly Dictionary<_states, BaseState> _stateDictionary = new();
        private StateMachineController _stateMachineController;

        public StateFactory(StateMachineController stateMachineController)
        {
            _stateDictionary[_states.IDLE] = new IdleState(stateMachineController, this);
            _stateDictionary[_states.WALK] = new WalkingState(stateMachineController, this);
            _stateDictionary[_states.JOG] = new JoggingState(stateMachineController, this);
            _stateDictionary[_states.RUN] = new RunningState(stateMachineController, this);
            _stateDictionary[_states.LIGHTATTACK] = new LightAttackState(stateMachineController, this);
            _stateDictionary[_states.HEAVYATTACK] = new HeavyAttackState(stateMachineController, this);
            _stateDictionary[_states.SPRINTATTACK] = new SprintAttackState(stateMachineController, this);
            _stateDictionary[_states.INAIRSTATE] = new InAirState(stateMachineController, this);
        }

        public BaseState IdleState()
        {
            return _stateDictionary[_states.IDLE];
        }
        
        public BaseState WalkingState()
        {
            return _stateDictionary[_states.WALK];
        }

        public BaseState JoggingState()
        {
            return _stateDictionary[_states.JOG];
        }
        
        public BaseState RunningState()
        {
            return _stateDictionary[_states.RUN];
        }

        public BaseState LightAttackState()
        {
            return _stateDictionary[_states.LIGHTATTACK];
        }
        
        public BaseState HeavyAttackState()
        {
            return _stateDictionary[_states.HEAVYATTACK];
        }
        
        public BaseState SprintAttackState()
        {
            return _stateDictionary[_states.SPRINTATTACK];
        }

        public BaseState InAirState()
        {
            return _stateDictionary[_states.INAIRSTATE];
        }
    }
}
