using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TapConfig", menuName = "Configs/TapConfig")]
public class TapConfig : ScriptableObject
{
    public int PointsCount;
    [Header("Skills")]
    public List<Skill> Skills;
}

[System.Serializable]
public class Skill
{
    public string SkillName;
    public int Value;
    public int Cost;
}
