using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    [SerializeField] UIManager uiManager;
    [SerializeField] SettingsPopUp settingsPopUp;

    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");
        Close();
        settingsPopUp.Open();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
        //Messenger.Broadcast(GameEvent.POPUP_OPEN);
        uiManager.SetGameActive(true);
    }
}
