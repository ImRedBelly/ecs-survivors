using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
    public sealed class AddEnchantsToHolderSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _holders;
        private readonly IGroup<GameEntity> _enchants;

        public AddEnchantsToHolderSystem(GameContext gameContext)
        {
            _holders = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantHolder));

            _enchants = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.EnchantTypeId,
                GameMatcher.TimeLeft));
        }

        public void Execute()
        {
            foreach (var holder in _holders)
            foreach (var enchant in _enchants)
            {
                holder.EnchantHolder.AddEnchant(enchant.EnchantTypeId);
            }
        }
    }
}