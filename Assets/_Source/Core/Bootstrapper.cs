using Core.GameStates;
using Events;
using Services;
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