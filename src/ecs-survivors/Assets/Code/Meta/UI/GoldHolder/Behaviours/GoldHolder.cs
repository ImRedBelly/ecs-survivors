using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.GoldHolder.Behaviours
{
    public class GoldHolder : MonoBehaviour
    {
        [SerializeField] private TMP_Text amount;
        [SerializeField] private TMP_Text boost;

        private IStorageUIService _storageUIService;


        [Inject]
        private void Construct(IStorageUIService storageUIService)
        {
            _storageUIService = storageUIService;
        }

        private void Start()
        {
            _storageUIService.GoldChange += UpdateGold;
            _storageUIService.GoldBoostChange += UpdateBoost;
            UpdateGold();
        }

        private void OnDestroy()
        {
            _storageUIService.GoldChange -= UpdateGold;
            _storageUIService.GoldBoostChange -= UpdateBoost;
        }

        private void UpdateGold()
        {
            amount.SetText(_storageUIService.CurrentGold.ToString("0"));
        }

        private void UpdateBoost()
        {
            float boostValue = _storageUIService.GoldGainBoost;

            if (boostValue > 0)
            {
                boost.gameObject.SetActive(true);
                boost.SetText(boostValue.ToString("+0%"));
            }
            else
            {
                boost.gameObject.SetActive(false);
            }
        }
    }
}