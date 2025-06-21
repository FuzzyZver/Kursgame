using UnityEngine;
using Leopotam.Ecs;

public class BuySkillActor: Actor
{
    [SerializeField] private int _skillType;

    public void BuySkill()
    {
        GetWorld().NewEntity().Get<BuySkillEvent>().SkillType = _skillType;
    }
}
