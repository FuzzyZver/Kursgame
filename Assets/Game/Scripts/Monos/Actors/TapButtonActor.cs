using UnityEngine;
using Leopotam.Ecs;

public class TapButtonActor: Actor
{
    public void Tapped()
    {
        GetWorld().NewEntity().Get<TapEvent>();
    }
}
