namespace F3Lib.Patterns.State
{
    public class Transition<TTrigger, TState> : ITransition<TTrigger, TState> where TState : IState
    {
        private TTrigger _trigger;
        private TState _state;
        private TState _targetState;

        public Transition(TState state)
        {
            _state = state;
        }

        public ITransition<TTrigger, TState> Bind(TTrigger trigger, TState targetState)
        {
            _trigger = trigger;
            _targetState = targetState;

            return this;
        }

        public ITransition<TTrigger, TState> ToSelf(TTrigger trigger)
        {
            _targetState = _state;
            _trigger = trigger;

            return this;
        }

        public TState GetState() => _state;
        public TState GetTarget() => _targetState;
        public TTrigger GetTrigger() => _trigger;
    }
}