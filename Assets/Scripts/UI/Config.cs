using System;
using PhaseControl;
using UI.PhaseDescription;
using UnityEngine;
using Util;

namespace UI
{
    public class Config : DisposableContainerMonoBehaviour
    {
        [SerializeField] private PhaseDescriptionScrollView ScrollView;

        private void Awake()
        {
            PhaseDescriptionScrollVM phaseDescriptionScrollVM = new PhaseDescriptionScrollVM(PhaseController.Instance);
            AddDisposable(phaseDescriptionScrollVM);
            ScrollView.Bind(phaseDescriptionScrollVM);
        }
    }
}