using Code.Gameplay;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;

// using Code.Meta;
// using Code.Meta.UI.GoldHolder.Service;
// using Code.Meta.UI.Shop.Service;

namespace Code.Infrastructure.States.GameStates
{
    public class HomeScreenState : IState, IUpdateable
    {
        private readonly ISystemFactory _systemsFactory;
        private readonly GameContext _gameContext;

        private HomeScreenFeature _homeScreenFeature;
        // private readonly IStorageUIService _storage;
        // private readonly IShopUIService _shopUIService;

        public HomeScreenState(
            ISystemFactory systemsFactory,
            GameContext gameContext
            // ,
            // IStorageUIService storage,
            // IShopUIService shopUIService
        )
        {
            _systemsFactory = systemsFactory;
            _gameContext = gameContext;
            // _storage = storage;
            // _shopUIService = shopUIService;
        }

        public void Enter()
        {
            _homeScreenFeature = _systemsFactory.Create<HomeScreenFeature>();
            _homeScreenFeature.Initialize();
        }

        public void Update()
        {
            _homeScreenFeature.Execute();
            _homeScreenFeature.Cleanup();
        }

        public void Exit()
        {
            // _storage.Cleanup();
            // _shopUIService.Cleanup();

            _homeScreenFeature.DeactivateReactiveSystems();
            _homeScreenFeature.ClearReactiveSystems();

            DestructEntities();

            _homeScreenFeature.Cleanup();
            _homeScreenFeature.TearDown();
            _homeScreenFeature = null;
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _gameContext.GetEntities())
                entity.isDestructed = true;
        }
    }
}