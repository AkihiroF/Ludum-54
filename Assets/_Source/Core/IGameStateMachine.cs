using Core.GameStates;

namespace Core
{
    public interface IGameStateMachine
    {
        public void SwitchGameState<T>() where T : IGameState;
    }
}