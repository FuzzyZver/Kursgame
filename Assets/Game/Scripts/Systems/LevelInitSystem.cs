using UnityEngine;
using Leopotam.Ecs;

public class LevelInitSystem: Injects, IEcsInitSystem
{
    public void Init()
    {
        UI.TapButtonActor.Init(EcsWorld);
        UI.BoosterActor.Init(EcsWorld);
    }
}
