using UnityEngine;
using Leopotam.Ecs;

public class TapButtonActor: Actor
{
    
    public override void ExpandEntity(EcsEntity entity)
    {
        entity.Get<TapButtonRef>();
    }

    public void Tapped()
    {
        GetWorld().NewEntity().Get<TapEvent>();
    }
}
