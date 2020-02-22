using System;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class UIDamage : MonoBehaviour
    {
        public Player Player;

        public Text DamageText;

        private void Awake()
        {
//            Player.OnDamaged += ShowDamage;
            ExampleEventBus.SubscribeOnEvent("Damage", ShowDamage);
        }

        private void ShowDamage(int damage)
        {
            DamageText.text = damage.ToString();
        }

        private void OnDestroy()
        {
            Player.OnDamaged -= ShowDamage;
        }
    }
}