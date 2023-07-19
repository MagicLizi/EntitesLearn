using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainThread
{
    public class RotationSpeedAuthoring : MonoBehaviour
    {
        [SerializeField] public float degreesPerSec = 360f;

        class Baker : Baker<RotationSpeedAuthoring>
        {
            public override void Bake(RotationSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotationSpeed
                {
                    RadiansPerSecond =  math.radians(authoring.degreesPerSec)
                });
            }
        }

        public struct RotationSpeed : IComponentData
        {
            public float RadiansPerSecond;
        }
    }
}
