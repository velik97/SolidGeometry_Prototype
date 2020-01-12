using PhaseControl;
using UI.PhaseDescription;
using UI.ResetPosition;
using UI.SceneRotation;
using UnityEngine;
using Util;
using Util.EventBusSystem;

namespace UI
{
    public class Config : DisposableContainerMonoBehaviour, IPhaseControllerLifeCycleHandler
    {
        [SerializeField] private PhaseDescriptionScrollView m_ScrollView;
        [SerializeField] private SceneRotationView m_SceneRotationView;
        [SerializeField] private ResetPositionView m_ResetPositionView;
        
        private PhaseDescriptionScrollVM m_PhaseDescriptionScrollVM;
        private SceneRotationVM m_SceneRotationVM;
        private ResetPositionVM m_ResetPositionVM;

        private void Awake()
        {
            AddDisposable(EventBus.Subscribe(this));
            m_SceneRotationView.gameObject.SetActive(false);
            m_ResetPositionView.gameObject.SetActive(false);
        }
        
        public void HandlePhaseControllerInstantiated(PhaseController phaseController)
        {
            m_PhaseDescriptionScrollVM = new PhaseDescriptionScrollVM(phaseController);
            AddDisposable(m_PhaseDescriptionScrollVM);
            m_ScrollView.Bind(m_PhaseDescriptionScrollVM);

            m_SceneRotationVM = new SceneRotationVM(phaseController);
            AddDisposable(m_SceneRotationVM);
            m_SceneRotationView.Bind(m_SceneRotationVM);

            m_ResetPositionVM = m_ResetPositionView.CreateViewModelAndBind();
            AddDisposable(m_ResetPositionVM);
        }

        public void HandlePhaseControllerDestroyed(PhaseController phaseController)
        {
            m_PhaseDescriptionScrollVM?.Dispose();
            m_PhaseDescriptionScrollVM = null;
            
            m_SceneRotationVM?.Dispose();
            m_SceneRotationVM = null;
            
            m_ResetPositionVM?.Dispose();
            m_ResetPositionVM = null;
        }
    }
}