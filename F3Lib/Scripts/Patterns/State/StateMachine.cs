using System.Collections.Generic;
using System.Linq;

namespace F3Lib.Patterns.State
{
    public class StateMachine<TTrigger, TState> where TState : IState
    {
        private List<Transition<TTrigger, TState>> _transitions;
        private TState _currentState;

        public StateMachine(TState initState)
        {
            _currentState = initState;
            _currentState.Execute();
            _transitions.Add(new Transition<TTrigger, TState>(initState));
        }

        public ITransition<TTrigger, TState> Configure(TState state)
        {
            var configureable =
                _transitions.First(transition => transition.GetState().Equals(state));

            if(configureable == null)
            {
                Transition<TTrigger, TState> transition = new Transition<TTrigger, TState>(state);
                _transitions.Add(transition);
                configureable = transition;
            }

            return configureable;
        }

        public void Fire(TTrigger trigger)
        {
            var target
                = _transitions.First(transition => transition.GetState().Equals(_currentState) ||
                transition.GetTrigger().Equals(trigger));

            _currentState = target.GetTarget();
            _currentState.Execute();
        }
    }
}