using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public class StorageUIService : IStorageUIService
    {
        public event Action GoldChange;
        public event Action GoldBoostChange;
        public float CurrentGold { get; private set; }
        public float GoldGainBoost { get; private set; }

        public void UpdateCurrentGold(float gold)
        {
            if (Math.Abs(CurrentGold - gold) > float.Epsilon)
            {
                CurrentGold = gold;
                GoldChange?.Invoke();
            }
        }

        public void UpdateGoldGainBoost(float boost)
        {
            GoldGainBoost = boost;
            GoldBoostChange?.Invoke();
        }

        public void Cleanup()
        {
            CurrentGold = 0;
            GoldChange = null;
            GoldBoostChange = null;
        }
    }
}