using MainThread;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct RotationSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        //至少有一个MThread组件 ，就会更新
        state.RequireForUpdate<MThread>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        // foreach(var (transform, speed) in 
        //         SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotationSpeedAuthoring.RotationSpeed>>())
        // {
        //     transform.ValueRW = transform.ValueRO.RotateY(speed.ValueRO.RadiansPerSecond * deltaTime);
        // }

        foreach (var action in SystemAPI.Query<ActionAspect>())
        {
            action.Rotate(deltaTime);
        }
    }
}

readonly partial struct ActionAspect : IAspect
{
    private readonly RefRW<LocalTransform> transform;
    private readonly RefRO<RotationSpeedAuthoring.RotationSpeed> speed;

    public void Rotate(float deltaTime)
    {
        transform.ValueRW = transform.ValueRO.RotateY(speed.ValueRO.RadiansPerSecond * deltaTime);
    }
}
