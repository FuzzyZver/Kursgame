using UnityEngine;
using Leopotam.Ecs;

public class TextNotifySystem: Injects, IEcsRunSystem
{
    private EcsFilter<TapEvent> _tapEventFilter;
    private EcsFilter<NotifyTextEvent> _notifyTextEventFilter;

    public void Run()
    {
        foreach(int i in _notifyTextEventFilter)
        {
            NotifyView notifyView = GameObject.Instantiate(GameConfig.UIConfig.NotifyView, UI.TextNotifySpawnPoint);
            notifyView.SetText(_notifyTextEventFilter.Get1(i).text);
        }

        foreach(int i in _tapEventFilter)
        {
            NotifyView notifyView = GameObject.Instantiate(GameConfig.UIConfig.NotifyView, UI.TextNotifySpawnPoint);
            notifyView.SetText("Тык тык тык");
        }
    }
}
