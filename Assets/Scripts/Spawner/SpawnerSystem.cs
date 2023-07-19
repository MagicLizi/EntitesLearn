using Unity.Burst;
using Unity.Entities;

public partial struct SpawnerSystem : ISystem
{
    private uint updateCounter;

    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Spawner>();
        state.RequireForUpdate<Prefabs>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        
    }
}
