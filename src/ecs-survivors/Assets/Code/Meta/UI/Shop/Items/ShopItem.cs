using System;
using Code.Common.Entity;
using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop.Items
{
    public class ShopItem : MonoBehaviour
    {
        public ShopItemId id;

        public Image icon;
        public TextMeshProUGUI price;
        public TextMeshProUGUI duration;
        public TextMeshProUGUI boost;
        public Button buyButton;
        public CanvasGroup canvasGroup;

        public Color enoughColor;
        public Color notEnoughColor;

        private bool _isAvailable;
        private int _price;
        private float _currentGold;

        private IStorageUIService _storage;

        private bool EnoughGold => _currentGold >= _price;

        [Inject]
        private void Construct(IStorageUIService storage) =>
            _storage = storage;

        public void Setup(ShopItemConfig config)
        {
            id = config.ShopItemId;

            icon.sprite = config.Icon;
            price.text = config.Price.ToString();
            duration.text = TimeSpan.FromSeconds(config.Duration).ToString("m'm 's's'");
            boost.text = config.Boost.ToString("+0%");

            _price = config.Price;

            buyButton.onClick.AddListener(BuyItem);
        }

        private void Start()
        {
            _storage.GoldChange += UpdatePriceThreshold;
            UpdatePriceThreshold();
        }

        private void OnDestroy()
        {
            _storage.GoldChange -= UpdatePriceThreshold;
            buyButton.onClick.RemoveListener(BuyItem);
        }

        public void UpdateAvailability(bool value)
        {
            _isAvailable = value;
            canvasGroup.alpha = _isAvailable ? 1f : 0.7f;

            RefreshBuyButton();
        }

        private void UpdatePriceThreshold()
        {
            _currentGold = _storage.CurrentGold;
            price.color = EnoughGold ? enoughColor : notEnoughColor;

            RefreshBuyButton();
        }

        private void RefreshBuyButton() =>
            buyButton.interactable = EnoughGold & _isAvailable;

        private void BuyItem()
        {
            CreateMetaEntity.Empty()
                .AddShopItemId(id)
                .isBuyRequest = true;
        }
    }
}