using System;
using System.Collections.Generic;
using UI.ResetPosition;
using UnityEngine;
using Util;
using Util.EventBusSystem;

namespace PhaseControl
{
    public class PhaseController : DisposableContainerMonoBehaviour, IResetPositionHandler
    {
        public List<PhaseObject> Phases;

        private int m_CurrentStageIndex = -1;

        public bool IsAtFirstStage => m_CurrentStageIndex <= 0;
        public bool IsAtLastStage => m_CurrentStageIndex >= (Phases?.Count-1 ?? 0);

        private void Awake()
        {
            InitializeStages();
            AddDisposable(EventBus.Subscribe(this));
        }

        private void InitializeStages()
        {
            foreach (var phase in Phases)
            {
                phase.Initialize();
            }
            SetNextStage();
        }

        public void SetStage(int number)
        {
            if (number < 0 || number > Phases.Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (number < m_CurrentStageIndex)
            {
                while (number < m_CurrentStageIndex)
                {
                    SetPreviousStage();
                }
            }
            else if (number > m_CurrentStageIndex)
            {
                while (number > m_CurrentStageIndex)
                {
                    SetNextStage();
                }
            }
        }

        public void SetNextStage()
        {
            if (IsAtLastStage)
            {
                return;
            }
            m_CurrentStageIndex++;
            Phases[m_CurrentStageIndex].SetActive(true);
        
        }

        public void SetPreviousStage()
        {
            if (IsAtFirstStage)
            {
                return;
            }
            Phases[m_CurrentStageIndex].SetActive(false);
            m_CurrentStageIndex--;

        }

        public void HandleResetPosition()
        {
            EventBus.TriggerEvent<IPhaseControllerLifeCycleHandler>(h => h.HandlePhaseControllerDestroyed(this));
            gameObject.SetActive(false);
        }
    }

    [Serializable]
    public class PhaseObject
    {
        public string Name;
        [TextArea]
        public string Description;
        [SerializeField] private List<StageObject> Stages;

        public void SetActive(bool value)
        {
            foreach (StageObject stage in Stages)
            {
                stage.GameObject.SetActive(value ? stage.Active : !stage.Active);
            }
        }

        public void Initialize()
        {
            foreach (StageObject stage in Stages)
            {
                stage.GameObject.SetActive(false);
            }
        }
    }

    [Serializable]
    public class StageObject
    {
        public GameObject GameObject;
        public bool Active;
    }
}