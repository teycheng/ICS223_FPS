using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : BasePopup
{
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Button okButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private OptionsPopup optionsPopUp;

    override public void Open()
    {
        base.Open();
        //gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
    }
    public void OnOKButton()
    {
        Close();
        optionsPopUp.Open();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopUp.Open();
        Messenger.Broadcast(GameEvent.POPUP_OPEN);
    }
    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " +((int)difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
}
