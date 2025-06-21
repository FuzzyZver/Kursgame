using UnityEngine;
using TMPro;
using Leopotam.Ecs;

public class DatabaseInteractActor: Actor
{
    [SerializeField] private string _nickname;
    [SerializeField] private TextMeshProUGUI _textPlaceholder;

    public void SetNickname()
    {
        _nickname = _textPlaceholder.text;
    }

    public void UploadPlayer()
    {
        GetWorld().NewEntity().Get<UploadPlayerEvent>().Nickname = _nickname;
    }

    public void LoadPlayer()
    {
        GetWorld().NewEntity().Get<LoadPlayerEvent>().Nickname = _nickname;
    }

    public void CleanData()
    {
        GetWorld().NewEntity().Get<CleanDataEvent>();
    }
}
