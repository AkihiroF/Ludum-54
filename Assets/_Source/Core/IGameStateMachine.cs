using System;
using _Source.Core.GameStates;

namespace _Source.Core
{
    public interface IGameStateMachine
    {
        public void SwitchGameState<T>() where T : IGameState;
    }
}