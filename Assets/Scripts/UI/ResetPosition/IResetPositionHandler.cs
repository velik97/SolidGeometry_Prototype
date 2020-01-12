using Util.EventBusSystem;

namespace UI.ResetPosition
{
    public interface IResetPositionHandler : IGlobalSubscriber
    {
        void HandleResetPosition();
    }
}