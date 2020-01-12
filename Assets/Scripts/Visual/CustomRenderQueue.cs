using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    [ExecuteInEditMode]
    public class CustomRenderQueue : MonoBehaviour {
 
        public UnityEngine.Rendering.CompareFunction comparison = UnityEngine.Rendering.CompareFunction.Always;
 
        public bool apply = false;
 
        private void Update()
        {
            if (apply)
            {
                apply = false;
                Debug.Log("Updated material val");
                Graphic image = GetComponent<Graphic>();
                Material existingGlobalMat = image.materialForRendering;
                Material updatedMaterial = new Material(existingGlobalMat);
                updatedMaterial.SetInt("unity_GUIZTestMode", (int)comparison);
                image.material = updatedMaterial;
            }
        }
    }
}