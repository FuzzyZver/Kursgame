using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;
    public DatabaseInteractActor DatabaseInteractActor;
    [SerializeField] private GameObject _buttonSoundOn;
    [SerializeField] private GameObject _buttonSoundOff;

    public void ApplySoundSetting(bool OnOff)
    {
        _gameConfig.CommonConfig.IsSoundOn = OnOff;
        if (_buttonSoundOn.activeSelf)
        {
            _buttonSoundOn.SetActive(false);
            _buttonSoundOff.SetActive(true);
        }
        else if (_buttonSoundOff.activeSelf)
        {
            _buttonSoundOff.SetActive(false);
            _buttonSoundOn.SetActive(true);
        }
    }
}
