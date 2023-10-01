using _Source.Core;
using _Source.Core.GameStates;
using _Source.Events;
using _Source.Services;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [Inject] private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine.SwitchGameState<BindingState>();
            Signals.Get<OnUpdateGameState>().Dispatch();
            _stateMachine.SwitchGameState<InGameState>();
        }
    }
}