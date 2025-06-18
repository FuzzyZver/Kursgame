using UnityEngine;

[CreateAssetMenu(fileName = "TapConfig", menuName = "Configs/TapConfig")]
public class TapConfig : ScriptableObject
{
    public int PointsCount;
    public int OneTapValue;
    public int AutoTapValue;
    public int BoostTimer;
}
