using Leopotam.Ecs;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    private EcsWorld _ecsWorld;

    public void Init(EcsWorld world)
    {
        _ecsWorld = world;
    }

    public EcsWorld GetWorld() => _ecsWorld;
}