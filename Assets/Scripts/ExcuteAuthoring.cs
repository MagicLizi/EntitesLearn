using Unity.Entities;
using UnityEngine;

public class ExecuteAuthoring : MonoBehaviour
{
    public bool NeedMain;

    public bool NeedIJob;

    public bool NeedPrefab;
    // Start is called before the first frame update
    class Baker : Baker<ExecuteAuthoring>
    {
        public override void Bake(ExecuteAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            if(authoring.NeedMain) AddComponent<MThread>(entity);
            if(authoring.NeedIJob) AddComponent<IJob>(entity);
            if(authoring.NeedPrefab) AddComponent<Prefabs>(entity);
        }
    }
}

public struct MThread : IComponentData
{
    
}

public struct IJob : IComponentData
{
    
}

public struct Prefabs : IComponentData
{
    
}