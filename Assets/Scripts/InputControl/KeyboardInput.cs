using PhaseControl;
using UnityEngine;

namespace InputControl
{
    public class KeyboardInput : MonoBehaviour
    {
        public PhaseController m_PhaseController;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_PhaseController.SetNextStage();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_PhaseController.SetPreviousStage();
            }
        }
    }
}