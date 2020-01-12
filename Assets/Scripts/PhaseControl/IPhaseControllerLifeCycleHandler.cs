using Util.EventBusSystem;

namespace PhaseControl
{
    public interface IPhaseControllerLifeCycleHandler : IGlobalSubscriber
    {
        void HandlePhaseControllerInstantiated(PhaseController phaseController);
        void HandlePhaseControllerDestroyed(PhaseController phaseController);
    }
}