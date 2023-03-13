using O8C;
using UnityEngine;


/// <summary>
/// This component handles "show/hide avatar" events.
/// </summary>
public class LocalAvatarHideEventHandler : MonoBehaviour {

    /// <summary>The avatar GameObject.</summary>
    public GameObject Avatar { private get; set; }



    /// <summary>
    /// Registers event handlers.
    /// </summary>
    void Start() {
        O8CSystem.Instance.EventManager.StartListening(App.ShowLocalAvatarEventID, OnShowAvatar);
        O8CSystem.Instance.EventManager.StartListening(App.HideLocalAvatarEventID, OnHideAvatar); 
    }


    /// <summary>
    /// Unregisters event handlers.
    /// </summary>
    private void OnDestroy() {
        O8CSystem.Instance.EventManager.StopListening(App.ShowLocalAvatarEventID, OnShowAvatar);
        O8CSystem.Instance.EventManager.StopListening(App.HideLocalAvatarEventID, OnHideAvatar);
    }


    /// <summary>
    /// Callback called on "show avatar" event, this method sets the avatar visible.
    /// </summary>
    private void OnShowAvatar() {
        if (null != Avatar) {
            Avatar.SetActive(true);
        }
    }


    /// <summary>
    /// Callback called on "hide avatar" event, this method sets the avatar invisible.
    /// </summary>
    private void OnHideAvatar() {
        if (null != Avatar) {
            Avatar.SetActive(false);
        }
    }

}
