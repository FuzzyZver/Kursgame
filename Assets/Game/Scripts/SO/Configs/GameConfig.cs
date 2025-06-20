using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    public CommonConfig CommonConfig;
    public TapConfig TapConfig;
    public UIConfig UIConfig;
}
