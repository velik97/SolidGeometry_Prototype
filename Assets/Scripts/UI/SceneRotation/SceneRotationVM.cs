using PhaseControl;
using UI.MVVM;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.SceneRotation
{
    public class SceneRotationVM : ViewModel
    {
        private PhaseController m_PhaseController;

        private Quaternion m_InitialRotation;
        
        private float m_StartPoint;
        private float m_Coeff = .5f;

        private bool m_IsRotating = false;

        public SceneRotationVM()
        {
        }

        public SceneRotationVM(PhaseController phaseController)
        {
            m_PhaseController = phaseController;
        }

        public void StartDrag(PointerEventData data)
        {
            m_InitialRotation = m_PhaseController.transform.rotation;
            m_StartPoint = data.position.x;
            m_IsRotating = true;
        }

        public void EndDrag(PointerEventData data)
        {
            ProcessDrag(data);
            m_IsRotating = false;
        }

        public void ProcessDrag(PointerEventData data)
        {
            if (!m_IsRotating)
                return;
            float rotationY = - (data.position.x - m_StartPoint) * m_Coeff;
            Quaternion rotation = Quaternion.Euler(0, rotationY, 0);
            m_PhaseController.transform.rotation = m_InitialRotation * rotation;
        }
    }
}