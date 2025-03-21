using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePopup : MonoBehaviour
{
    public virtual void Open()
    {
        //gameObject.SetActive(true);
        if (!IsActive())
        {
            this.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPEN);
        }
        else
        {
            Debug.LogError(this + ".Open() – trying to open a popup that is active!");
        }
    }
    public virtual void Close()
    {
        if (IsActive())
        {
            //this.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSE);

        }
        else
        {
            Debug.LogError(this + ".Close() – trying to close a popup that is not active!");
        }
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
