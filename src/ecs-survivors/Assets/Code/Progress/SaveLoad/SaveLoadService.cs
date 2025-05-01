using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Serialization;
using Code.Progress.Data;
using Code.Progress.Provider;
using UnityEngine;

namespace Code.Progress.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly MetaContext _metaContext;
        private readonly IProgressProvider _progressProvider;
        private readonly ITimeService _timeService;
        private const string ProgressKey = "PlayerProgress";

        public bool HasSavedProgress => PlayerPrefs.HasKey(ProgressKey);


        public SaveLoadService(MetaContext metaContext,
            IProgressProvider progressProvider,
            ITimeService timeService)
        {
            _metaContext = metaContext;
            _progressProvider = progressProvider;
            _timeService = timeService;
        }

        public void CreateProgress()
        {
            _progressProvider.SetProgressData(new ProgressData()
            {
                LastSimulationTickTime = _timeService.UtcNow
            });
        }

        public void SaveProgress()
        {
            PreserveMetaEntities();

            PlayerPrefs.SetString(ProgressKey, _progressProvider.ProgressData.ToJson());
            PlayerPrefs.Save();
        }

        public void LoadProgress()
        {
            string serializedProgress = PlayerPrefs.GetString(ProgressKey);
            _progressProvider.SetProgressData(serializedProgress.FromJson<ProgressData>());

            HydrateMetaEntities();
        }

        private void HydrateMetaEntities()
        {
            List<EntitySnapshot> snapshots = _progressProvider.EntityData.MetaEntitySnapshots;
            foreach (var snapshot in snapshots)
            {
                _metaContext.CreateEntity().HydrateWith(snapshot);
            }
        }

        private void PreserveMetaEntities()
        {
            _progressProvider.EntityData.MetaEntitySnapshots = _metaContext
                .GetEntities().Where(RequiresSave)
                .Select(e => e.AsSavedEntity())
                .ToList();
        }

        private bool RequiresSave(MetaEntity e)
        {
            return e.GetComponents().Any(c => c is ISavedComponent);
        }
    }
}