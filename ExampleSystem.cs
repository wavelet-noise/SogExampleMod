using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ISog
{
    public class ExampleSystem : IEcsRunSystem
    {
        EcsWorldInject world = default;

        EcsPoolInject<Ecs.Position> posPool = default;
        EcsPoolInject<Ecs.Destination> destPool = default;

        EcsFilterInject<Inc<Ecs.Position, Ecs.Destination>> posFilter = default;

        public void Run(EcsSystems systems)
        {
            foreach (var pos in posFilter.Value)
            {
                ref var entPos = ref posPool.Value.Get(pos);
                ref var entDest = ref destPool.Value.Get(pos);

                entPos.position = entDest.destination;
            }
        }
    }
}
