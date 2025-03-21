using UnityEngine;

public class ActiveDuringGamePlay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }

    // Update is called once per frame
    public virtual void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }

    public void OnGameActive()
    {
        this.enabled = true;
    }

    public void OnGameInactive()
    {
        this.enabled = false;
    }
}
