using UnityEngine;
using Leopotam.Ecs;

public class CleanDataSystem: Injects, IEcsRunSystem
{
    private EcsFilter<CleanDataEvent> _cleanDataEventFilter;

    public void Run()
    {
        foreach (int i in _cleanDataEventFilter)
        {
            GameConfig.CommonConfig.Nickname = "";
            GameConfig.CommonConfig.HavePets[0] = false;
            GameConfig.CommonConfig.HavePets[1] = false;
            GameConfig.CommonConfig.HavePets[2] = false;

            GameConfig.TapConfig.PointsCount = 0;
            GameConfig.TapConfig.Skills[0].Value = 1;
            GameConfig.TapConfig.Skills[0].Cost = 2;
            GameConfig.TapConfig.Skills[1].Value = 1;
            GameConfig.TapConfig.Skills[1].Cost = 2;
            GameConfig.TapConfig.Skills[2].Value = 2;
            GameConfig.TapConfig.Skills[2].Cost = 4;
        }
    }
}
