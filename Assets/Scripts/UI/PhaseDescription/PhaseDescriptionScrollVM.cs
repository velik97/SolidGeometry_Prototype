using System.Collections.Generic;
using PhaseControl;
using UI.MVVM;

namespace UI.PhaseDescription
{
    public class PhaseDescriptionScrollVM : ViewModel
    {
        public List<PhaseDescriptionVM> PhaseDescriptionVMs;
        private PhaseController m_PhaseController;

        public PhaseDescriptionScrollVM()
        {
        }

        public PhaseDescriptionScrollVM(PhaseController phaseController)
        {
            m_PhaseController = phaseController;
            PhaseDescriptionVMs = new List<PhaseDescriptionVM>();

            for (var i = 0; i < m_PhaseController.Phases.Count; i++)
            {
                PhaseDescriptionVMs.Add(new PhaseDescriptionVM(i, m_PhaseController.Phases[i]));
            }
        }

        public void SetStage(int number)
        {
            m_PhaseController.SetStage(number);
        }
    }
}