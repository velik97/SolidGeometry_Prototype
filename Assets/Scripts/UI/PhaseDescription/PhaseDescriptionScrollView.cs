using System;
using DanielLochner.Assets.SimpleScrollSnap;
using UI.MVVM;
using UnityEngine;
using Util;

namespace UI.PhaseDescription
{
    public class PhaseDescriptionScrollView : View<PhaseDescriptionScrollVM>
    {
        [SerializeField] private SimpleScrollSnap m_Scroll;
        [SerializeField] private PhaseDescriptionView m_DescriptionPrefab;

        public override void Bind(PhaseDescriptionScrollVM viewModel)
        {
            base.Bind(viewModel);

            foreach (PhaseDescriptionVM descriptionVM in viewModel.PhaseDescriptionVMs)
            {
                CreateNewPhaseDescription(descriptionVM);
            }
            
            m_Scroll.onPanelSelected.AddListener(() =>
            {
                viewModel.SetStage(m_Scroll.TargetPanel);
            });
        }
        
        private void CreateNewPhaseDescription(PhaseDescriptionVM vm)
        {
            PhaseDescriptionView newDescription = m_Scroll.Add(m_DescriptionPrefab, vm.Number);
            newDescription.Bind(vm);
        }

        protected override void DestroyViewImplementation()
        {
        }
    }
}