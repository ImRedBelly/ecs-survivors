using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public sealed class EnemyDropLootSystem : IExecuteSystem
    {
        private readonly ILootFactory _lootFactory;
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDropLootSystem(GameContext gameContext, ILootFactory lootFactory)
        {
            _lootFactory = lootFactory;
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy,
                GameMatcher.WorldPosition,
                GameMatcher.ProcessingDeath,
                GameMatcher.Dead
            ));
        }

        public void Execute()
        {
            foreach (var enemy in _enemies)
            {
                if (Random.Range(0, 1f) <= 0.15f)
                {
                    _lootFactory.CreateLootItem(LootTypeId.HealingItem, enemy.WorldPosition);
                }
                else if (Random.Range(0, 1f) <= 0.15f)
                {
                    _lootFactory.CreateLootItem(LootTypeId.PoisonEnchantItem, enemy.WorldPosition);
                }
                else if (Random.Range(0, 1f) <= 0.15f)
                {
                    _lootFactory.CreateLootItem(LootTypeId.ExplosiveEnchantItem, enemy.WorldPosition);
                }
                else
                {
                    _lootFactory.CreateLootItem(LootTypeId.ExperienceGem, enemy.WorldPosition);
                }
            }
        }
    }
}