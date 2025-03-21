using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    //private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image crossHair;
    [SerializeField] private OptionsPopup optionsPopup;
    [SerializeField] private SettingsPopUp settingsPopUp;
    private int popupsActive = 0;

    private Color fullHealth = Color.green;
    private Color zeroHealth = Color.red;
    
    // update score display
    private void Start()
    {
        //UpdateScore(score);
        SetHealthBar(1.0f);
  
        Messenger.AddListener(GameEvent.POPUP_OPEN, OnPopUpOpened);
        Messenger.AddListener(GameEvent.POPUP_CLOSE, OnPopUpClosed);
        Messenger<float>.AddListener(GameEvent.HEALTH_CHANGED, OnHealthChanged);
    }

    private void Update()
    {
        if (popupsActive == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !optionsPopup.IsActive() && !settingsPopUp.IsActive())
            {
                optionsPopup.Open();
            }
        }
    }
    public void UpdateScore(int newScore)
    {
        scoreText.text = "Score: "  +newScore.ToString();
    }

    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1; // unpause the game
            Cursor.lockState = CursorLockMode.Locked; // lock cursor at center
            Cursor.visible = false; // hide cursor
            crossHair.gameObject.SetActive(true); // show the crosshair
            Messenger.Broadcast(GameEvent.GAME_ACTIVE);
            //this.enabled = false;
        }
        else
        {
            Time.timeScale = 0; // pause the game
            Cursor.lockState = CursorLockMode.None; // let cursor move freely
            Cursor.visible = true; // show the cursor
            crossHair.gameObject.SetActive(false); // turn off the crosshair
            Messenger.Broadcast(GameEvent.GAME_INACTIVE);

        }

    }

    void OnHealthChanged(float healthPercentage)
    {
        SetHealthBar(healthPercentage);
    }

    public void SetHealthBar(float healthPercentage)
    {
        healthBar.fillAmount = healthPercentage;
        healthBar.color = Color.Lerp(zeroHealth, fullHealth, healthPercentage);
    }


    void OnPopUpOpened()
    {
        if (popupsActive == 0)
        {
            SetGameActive(false);
        }
        popupsActive++;
        //Debug.Log("pop ups active: " + popupsActive);
    }

    void OnPopUpClosed()
    {
        popupsActive--;
        if(popupsActive==0)
        {
            SetGameActive(true);
        }
        //Debug.Log("pop ups active: " + popupsActive);

    }
}
