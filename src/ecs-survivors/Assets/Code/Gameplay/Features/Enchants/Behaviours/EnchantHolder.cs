using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder : MonoBehaviour
    {
        [SerializeField] private Transform enchantLayout;

        private IEnchantUIFactory _enchantUIFactory;
        private readonly List<Enchant> _enchants = new();

        [Inject]
        private void Construct(IEnchantUIFactory enchantUIFactory)
        {
            _enchantUIFactory = enchantUIFactory;
        }

        public void AddEnchant(EnchantTypeId enchantTypeId)
        {
            if (EnchantAlreadyHeld(enchantTypeId))
            {
                return;
            }

            Enchant enchant = _enchantUIFactory.CreateEnchant(enchantTypeId, enchantLayout);

            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId enchantTypeId)
        {
            Enchant enchant = _enchants.Find(x => x.EnchantTypeId == enchantTypeId);
            if (enchant != null)
            {
                _enchants.Remove(enchant);
                Destroy(enchant.gameObject);
            }
        }


        private bool EnchantAlreadyHeld(EnchantTypeId enchantTypeId)
        {
            return _enchants.Find(x => x.EnchantTypeId == enchantTypeId) != null;
        }
    }
}