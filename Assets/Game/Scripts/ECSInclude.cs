using UnityEngine;
using Leopotam.Ecs;

public class ECSInclude : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private UI _ui;
    private EcsWorld _ecsWorld;
    private EcsSystems _ecsSystems;

    public void Awake()
    {
        _ecsWorld = new EcsWorld();
        _ecsSystems = new EcsSystems(_ecsWorld);

        _ecsSystems
            .Add(new LevelInitSystem())
            .Add(new TapSystem())
            .Add(new BuySystem())

            .Add(new LoadPLayerSystem())
            .Add(new UploadPlayerSystem())
            .Add(new CleanDataSystem())

            .OneFrame<TapEvent>()
            .OneFrame<BoostEvent>()
            .OneFrame<LoadPlayerEvent>()
            .OneFrame<UploadPlayerEvent>()
            .OneFrame<CleanDataEvent>()

            .Add(new TextNotifySystem())
            .OneFrame<BuySkillEvent>()
            .OneFrame<NotifyTextEvent>()

            .Inject(_gameConfig)
            .Inject(_ecsWorld)
            .Inject(_ui)

            .Init();

    }

    public void Update()
    {
        _ecsSystems.Run();
    }

    public void OnDestroy()
    {
        _ecsSystems.Destroy();
        _ecsWorld.Destroy();
    }    
}
