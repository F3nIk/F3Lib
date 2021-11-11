namespace F3Lib.Patterns.State
{
    public class Transition<ITrigger, TState> : ITransition<ITrigger, TState> where TState : IState
    {
        private ITrigger _trigger;
        private TState _state;
        private TState _targetState;

        public Transition(TState state)
        {
            _state = state;
        }

        public ITransition<ITrigger, TState> Bind(ITrigger trigger, TState targetState)
        {
            _trigger = trigger;
            _targetState = targetState;

            return this;
        }

        public TState GetState() => _state;
        public TState GetTarget() => _targetState;
        public ITrigger GetTrigger() => _trigger;
    }
}