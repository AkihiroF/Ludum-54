using SO;

namespace Player
{
    public interface ISetterParameters
    {
        public void UpSizeParameters();
        public void DownSizeParameters();
        public void SetCurrentZone(ZoneParametersSo newZone);
    }
}