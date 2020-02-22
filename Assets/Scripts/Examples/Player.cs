using System;
using UnityEngine;

namespace Examples
{
    public class Player : MonoBehaviour
    {
        public event Action<int> OnDamaged;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bomb"))
            {
                ApplyDamage(5);
            }
        }

        private void ApplyDamage(int damage)
        {
//            OnDamaged?.Invoke(damage);
            ExampleEventBus.RaiseEvent("damage");
        }
    }
}