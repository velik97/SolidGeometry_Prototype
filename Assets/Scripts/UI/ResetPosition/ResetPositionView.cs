using System;
using UI.MVVM;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ResetPosition
{
    public class ResetPositionView : View<ResetPositionVM>
    {
        [SerializeField] private Button m_ResetButton;

        public override void Bind(ResetPositionVM viewModel)
        {
            base.Bind(viewModel);
            gameObject.SetActive(true);
            
            m_ResetButton.onClick.AddListener(viewModel.ResetPosition);
        }

        protected override void DestroyViewImplementation()
        {
            m_ResetButton.onClick.RemoveAllListeners();
            gameObject.SetActive(false);
        }
    }
}