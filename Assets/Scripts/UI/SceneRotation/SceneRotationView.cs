using System;
using UI.MVVM;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.SceneRotation
{
    [RequireComponent(typeof(Image))]
    public class SceneRotationView : View<SceneRotationVM>, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public override void Bind(SceneRotationVM viewModel)
        {
            base.Bind(viewModel);
            gameObject.SetActive(true);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            ViewModel.StartDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ViewModel.EndDrag(eventData);
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            ViewModel.ProcessDrag(eventData);
        }
        
        protected override void DestroyViewImplementation()
        {
            gameObject.SetActive(false);
        }
    }
}