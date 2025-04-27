using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
    public class Enchant : MonoBehaviour
    {
        public EnchantTypeId EnchantTypeId { get; private set; }
        [SerializeField] private Image iconEnchant;

        public void Set(EnchantConfig enchantConfig)
        {
            EnchantTypeId = enchantConfig.typeId;
            iconEnchant.sprite = enchantConfig.icon;
        }
    }
}