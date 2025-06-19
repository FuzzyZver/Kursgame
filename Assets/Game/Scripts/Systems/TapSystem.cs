using UnityEngine;
using Leopotam.Ecs;
using System.Threading.Tasks;

public class TapSystem: Injects, IEcsRunSystem
{
    private EcsFilter<TapEvent> _tapEventFilter;
    private EcsFilter<BoostEvent> _boostEventFilter;
    private int _booster = 1;
    private bool _boostStart = false;
    
    public void Run()
    {
        foreach (int i in _boostEventFilter)
        {
            if (!_boostStart)
            {
                Boosted();
            }
            else
            {
                EcsWorld.NewEntity().Get<NotifyTextEvent>().Text = ("Вы уже нажали на буст, подождите");
            }

        }
        foreach (int i in _tapEventFilter)
        {
            GameConfig.TapConfig.PointsCount += GameConfig.TapConfig.Skills[0].Value *_booster;
        }
    }

    public async void Boosted()
    {
        _boostStart = true;
        _booster++;
        await Task.Delay(GameConfig.TapConfig.Skills[2].Value*1000);
        _booster = 1;
        _boostStart= false;
    }
}
