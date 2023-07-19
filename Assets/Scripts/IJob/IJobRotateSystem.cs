using MainThread;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

public partial struct IJobRotateSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        //至少有一个MThread组件 ，就会更新
        state.RequireForUpdate<IJob>();
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var job = new RotationJob {deltaTime = SystemAPI.Time.DeltaTime };
        job.Schedule();
        // state.Dependency = job.Schedule(state.Dependency);
    }
}

[BurstCompile]
partial struct RotationJob : IJobEntity
{
    public float deltaTime;

    void Execute(ref LocalTransform transform, in RotationSpeedAuthoring.RotationSpeed speed)
    {
        transform = transform.RotateY(speed.RadiansPerSecond * deltaTime);
    }
}
