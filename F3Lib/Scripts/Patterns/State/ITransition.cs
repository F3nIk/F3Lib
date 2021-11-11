namespace F3Lib.Patterns.State
{
    public interface ITransition<ITrigger, TState> where TState : IState
    {
        ITransition<ITrigger, TState> Bind(ITrigger command, TState state);
        TState GetState();
        TState GetTarget();

    }
}