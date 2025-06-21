using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommonConfig", menuName = "Configs/CommonConfig")]
public class CommonConfig : ScriptableObject
{
    public string DataBasePath;
    public bool IsSoundOn;
    public string Nickname;
    [Header("Inventory")]
    public List<bool> HavePets;
}
