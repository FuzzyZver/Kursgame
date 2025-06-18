using UnityEngine;
using Leopotam.Ecs;

public class BoosterActor: Actor
{
    public override void ExpandEntity(EcsEntity entity)
    {
        entity.Get<TapButtonRef>();
    }

    public void SetBoost()
    {
        GetWorld().NewEntity().Get<BoostEvent>();
    }
}
