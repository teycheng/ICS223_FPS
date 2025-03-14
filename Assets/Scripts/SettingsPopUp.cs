using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SettingsPopUp : MonoBehaviour
{
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Button okButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private OptionsPopup optionsPopUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Open()
    {
        gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
    public void OnOKButton()
    {
        Close();
        optionsPopUp.Open();
        PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
    }

    public void OnCancelButton()
    {
        Close();
        optionsPopUp.Open();
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
