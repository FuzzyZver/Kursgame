using UnityEngine;

public class UI : MonoBehaviour
{
    public TapButtonActor TapButtonActor;
    public BoosterActor BoosterActor;
    public RectTransform TextNotifySpawnPoint;
    [Header("Screens")]
    public ShopScreen ShopScreen;
    public SettingsScreen SettingsScreen;

    public void HideScreen(GameObject hideScreen)
    {
        hideScreen.SetActive(false);
    }

    public void ViewScreen(GameObject viewScreen)
    {
        viewScreen.SetActive(true);
    }
}
