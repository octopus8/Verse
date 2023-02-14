using O8C;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHider : MonoBehaviour {

    protected GameObject avatar;

    public GameObject Avatar { set { avatar = value; } }

    // Start is called before the first frame update
    void Start() {
        O8CSystem.Instance.EventManager.StartListening(App.ShowAvatarEventID, OnShowAvatar);
        O8CSystem.Instance.EventManager.StartListening(App.HideAvatarEventID, OnHideAvatar); 
    }




    private void OnShowAvatar() {
        avatar.SetActive(true);
    }


    private void OnHideAvatar() {
        avatar.SetActive(false);
    }

    private void OnDestroy() {
        O8CSystem.Instance.EventManager.StopListening(App.ShowAvatarEventID, OnShowAvatar);
        O8CSystem.Instance.EventManager.StopListening(App.HideAvatarEventID, OnHideAvatar);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
