using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] SettingsPopUp settingsPopUp;
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
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
        uiManager.SetGameActive(true);
    }
}
