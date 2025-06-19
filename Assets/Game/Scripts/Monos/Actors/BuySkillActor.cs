using UnityEngine;
using Leopotam.Ecs;

public class BuySkillActor: Actor
{
    [SerializeField] private int _skillType;

    public override void ExpandEntity(EcsEntity entity)
    {
        entity.Get<SkillCostComponent>().Cost = 1;
    }

    public void BuySkill()
    {
        GetWorld().NewEntity().Get<BuySkillEvent>().SkillType = _skillType;
    }
}
