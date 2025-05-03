using System;
using System.Collections.Generic;
using Code.Gameplay.Windows;
using Code.Meta.UI.GoldHolder.Service;
using Code.Meta.UI.Shop.Items;
using Code.Meta.UI.Shop.Service;
using Code.Meta.UI.Shop.UIFactory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop
{
    public class ShopWindow : BaseWindow
    {
        public Transform itemsLayout;
        public Button closeButton;
        public GameObject noItemsAvailable;
        private IWindowService _windowService;
        private IShopUIFactory _shopUIFactory;
        private IShopUIService _shopUIService;
        private IStorageUIService _storageUIService;
        private readonly List<ShopItem> _items = new();


        [Inject]
        private void Construct(
            IWindowService windowService,
            IShopUIFactory shopUIFactory,
            IShopUIService shopUIService,
            IStorageUIService storageUIService)
        {
            _shopUIService = shopUIService;
            _shopUIFactory = shopUIFactory;
            _windowService = windowService;
            _storageUIService = storageUIService;

            Id = WindowId.ShopWindow;
        }

        protected override void Initialize()
        {
            closeButton.onClick.AddListener(Close);
        }

        protected override void SubscribeUpdates()
        {
            _shopUIService.ShopChanged += Refresh;
            _storageUIService.GoldBoostChange += UpdateBoostersState;
            Refresh();
        }

        protected override void UnsubscribeUpdates()
        {
            _shopUIService.ShopChanged -= Refresh;
            _storageUIService.GoldBoostChange -= UpdateBoostersState;
        }

        protected override void Cleanup()
        {
            closeButton.onClick.RemoveListener(Close);
        }

        private void Refresh()
        {
            ClearItems();

            List<ShopItemConfig> availableConfigs = _shopUIService.GetAvailableShopItems;
            noItemsAvailable.SetActive(availableConfigs.Count == 0);

            FillItems(availableConfigs);
            UpdateBoostersState();
        }

        private void FillItems(List<ShopItemConfig> availableConfigs)
        {
            foreach (ShopItemConfig shopItemConfig in availableConfigs)
            {
                _items.Add(_shopUIFactory.CreateShopItem(shopItemConfig, itemsLayout));
            }
        }


        private void UpdateBoostersState()
        {
            bool itemsCanBeBought = Math.Abs(_storageUIService.GoldGainBoost - 0) <= float.Epsilon;
            foreach (var shopItem in _items)
            {
                shopItem.UpdateAvailability(itemsCanBeBought);
            }
        }

        private void ClearItems()
        {
            _items.ForEach(x => Destroy(x.gameObject));
            _items.Clear();
        }

        private void Close()
        {
            _windowService.Close(WindowId.ShopWindow);
        }
    }
}