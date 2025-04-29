using System;
using System.Collections;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
    public class AbilityCard : MonoBehaviour
    {
        public AbilityId AbilityId { get; private set; }

        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text description;
        [SerializeField] private Button button;
        [SerializeField] private GameObject stamp;

        private Action<AbilityId> _onSelected;

        public void Setup(AbilityId abilityId, AbilityLevel config, Action<AbilityId> onSelected)
        {
            AbilityId = abilityId;
            icon.sprite = config.icon;
            description.SetText(config.description);

            _onSelected = onSelected;

            button.onClick.AddListener(SelectCard);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }

        private void SelectCard()
        {
            StartCoroutine(StampAndReport());
        }

        private IEnumerator StampAndReport()
        {
            stamp.SetActive(true);
            yield return new WaitForSeconds(1f);

            _onSelected?.Invoke(AbilityId);
        }
    }
}