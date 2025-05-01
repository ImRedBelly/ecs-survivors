using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Data;
using Code.Progress.Provider;

// using Code.Progress.SaveLoad;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadProgressState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    private readonly IProgressProvider _progressProvider;
    // private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(
      IGameStateMachine stateMachine,
      // ISaveLoadService saveLoadService,
      IStaticDataService staticDataService,
      IProgressProvider progressProvider)
    {
      // _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
      _progressProvider = progressProvider;
    }

    public void Enter()
    {
      InitializeProgress();

      _stateMachine.Enter<ActualizeProgressState>();
    }

    private void InitializeProgress()
    {
      // if (_saveLoadService.HasSavedProgress)
        // _saveLoadService.LoadProgress();
      // else
         CreateNewProgress();
    }

    private void CreateNewProgress()
    {
      // _saveLoadService.CreateProgress();
      _progressProvider.SetProgressData(new ProgressData()
      {
        LastSimulationTickTime =  DateTime.UtcNow
      });
      CreateMetaEntity.Empty()
        .With(x => x.isStorage = true)
        .AddGold(0)
        .AddGoldPerSeconds(_staticDataService.AfkGainConfig.goldPerSeconds);
    }

    public void Exit()
    {
    }
  }
}