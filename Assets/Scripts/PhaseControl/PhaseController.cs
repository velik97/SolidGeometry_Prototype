using System;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace PhaseControl
{
    public class PhaseController : MonoSingleton<PhaseController>
    {
        public List<PhaseObject> Phases;
        public float ScaleFactor = 0.2f;

        private int m_CurrentStageIndex = -1;

        public bool IsAtFirstStage => m_CurrentStageIndex <= 0;
        public bool IsAtLastStage => m_CurrentStageIndex >= (Phases?.Count-1 ?? 0);

        private void Awake()
        {
            SetScale();
            InitializeStages();
        }

        private void InitializeStages()
        {
            foreach (var phase in Phases)
            {
                phase.Initialize();
            }
            SetNextStage();
        }

        private void SetScale()
        {
            transform.localScale = Vector3.one * ScaleFactor;
            LineRenderer[] lineRenderers = GetComponentsInChildren<LineRenderer>(true);
            List<Material> lineRendererMaterials = new List<Material>(); 
            
            // Set width of lines
            foreach (LineRenderer lineRenderer in lineRenderers)
            {
                lineRenderer.widthMultiplier *= ScaleFactor;
                if (!lineRendererMaterials.Contains(lineRenderer.material))
                {
                    lineRendererMaterials.Add(lineRenderer.material);
                }
            }
            
            // Set dashed line periods
            foreach (Material material in lineRendererMaterials)
            {
                Vector2 scale = material.mainTextureScale;
                scale.x /= ScaleFactor;
                material.mainTextureScale = scale;
            }
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