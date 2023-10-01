namespace ResourceSystem
{
    public interface IResource
    {
        void SubscribeToEvents();
        void UnSubscribeToEvents();
        void UpdateResourceCount();
    }
}