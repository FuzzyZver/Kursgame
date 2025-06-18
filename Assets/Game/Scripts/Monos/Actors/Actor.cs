using Leopotam.Ecs;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    private EcsEntity _ecsEntity;
    private EcsWorld _ecsWorld;

    public void Init(EcsWorld world)
    {
        _ecsEntity = world.NewEntity();
        _ecsWorld = world;
        ExpandEntity(_ecsEntity);
    }

    public EcsEntity GetEntity() => _ecsEntity;
    public EcsWorld GetWorld() => _ecsWorld;

    public abstract void ExpandEntity(EcsEntity entity);

}