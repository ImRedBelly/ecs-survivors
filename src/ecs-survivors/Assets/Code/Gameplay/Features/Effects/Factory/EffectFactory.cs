using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch (setup.effectTypeId)
            {
                case EffectTypeId.Unknown:
                    break;
                case EffectTypeId.Damage:
                    return CreateDamage(producerId, targetId, setup.value);
                case EffectTypeId.Heal:
                    return CreateHeal(producerId, targetId, setup.value);

                default:
                    throw new ArgumentOutOfRangeException();
            }

            throw new Exception($"Effect with type {setup.effectTypeId} does not exist");
        }

        private GameEntity CreateDamage(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .With(x => x.isEffect = true)
                    .With(x => x.isDamageEffect = true)
                    .AddEffectValue(value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                ;
        }

        private GameEntity CreateHeal(int producerId, int targetId, float value)
        {
            return CreateEntity.Empty()
                    .AddId(_identifierService.Next())
                    .With(x => x.isEffect = true)
                    .With(x => x.isHealEffect = true)
                    .AddEffectValue(value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                ;
        }
    }
}