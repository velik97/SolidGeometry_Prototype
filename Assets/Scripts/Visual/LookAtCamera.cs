using System;
using UnityEngine;

namespace Visual
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera m_Camera;

        private void Awake()
        {
            m_Camera = Camera.main;
        }

        private void LateUpdate()
        {
            if (m_Camera == null)
            {
                return;
            }
            transform.forward = m_Camera.transform.forward;
        }
    }
}