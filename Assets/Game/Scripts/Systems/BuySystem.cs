using UnityEngine;
using Leopotam.Ecs;

public class BuySystem: Injects, IEcsRunSystem
{
    private EcsFilter<BuySkillEvent> _buySkillEvent;

    public void Run()
    {
        foreach(int i in _buySkillEvent)
        {
            int skillType = _buySkillEvent.Get1(i).SkillType;
            if(GameConfig.TapConfig.PointsCount < GameConfig.TapConfig.Skills[skillType].Cost)
            {
                EcsWorld.NewEntity().Get<NotifyTextEvent>().Text = ("Вам не хватает очков для покупки(");
            }
            else
            {
                GameConfig.TapConfig.PointsCount -= GameConfig.TapConfig.Skills[skillType].Cost;
                GameConfig.TapConfig.Skills[skillType].Value *= 2;
                GameConfig.TapConfig.Skills[skillType].Cost *= 2;
                EcsWorld.NewEntity().Get<NotifyTextEvent>().Text = ($"Вы прокачали: {GameConfig.TapConfig.Skills[skillType].SkillName}");
            }
        }
    }
}
