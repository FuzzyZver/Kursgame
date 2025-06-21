using UnityEngine;
using Leopotam.Ecs;

public class BoosterActor: Actor
{
    public void SetBoost()
    {
        GetWorld().NewEntity().Get<BoostEvent>();
    }
}
