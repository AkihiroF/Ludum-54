namespace Core.GameStates
{
    public interface IGameState
    {
        public void OnEnter();
        public void OnExit();
        public void Update();
    }
}