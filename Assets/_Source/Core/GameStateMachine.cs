using System;
using System.Collections.Generic;
using _Source.Core.GameStates;
using _Source.Events;
using _Source.Services;

namespace _Source.Core
{
    public class GameStateMachine : IGameStateMachine, IDisposable
    {
        private readonly Dictionary<Type, IGameState> _gameStates;
        private IGameState _currentState;

        public GameStateMachine(List<IGameState> states)
        {
            _gameStates = new Dictionary<Type, IGameState>();
            foreach (var state in states)
            {
                _gameStates.Add(state.GetType(), state);
            }
            SubscribeToEvents();
        }

        public void Dispose()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeToEvents()
        {
            Signals.Get<OnUpdateGameState>().AddListener(UpdateState);
        }

        private void UnsubscribeFromEvents()
        {
            Signals.Get<OnUpdateGameState>().RemoveListener(UpdateState);
        }

        private void UpdateState()
        {
            _currentState?.Update();
        }

        public void SwitchGameState<T>() where T : IGameState
        {
            if (_gameStates.TryGetValue(typeof(T), out var gameState))
            {
                _currentState?.OnExit();
                
                _currentState = gameState;
                _currentState.OnEnter();
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}