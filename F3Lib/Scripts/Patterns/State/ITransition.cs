namespace F3Lib.Patterns.State
{
    public interface ITransition<TTrigger, TState> where TState : IState
    {
        ITransition<TTrigger, TState> Bind(TTrigger command, TState state);
        ITransition<TTrigger, TState> ToSelf(TTrigger command);
        TState GetState();
        TState GetTarget();

    }
}