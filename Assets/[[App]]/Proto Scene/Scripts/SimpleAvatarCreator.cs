using O8C;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAvatarCreator : AvatarCreator {

    #region Inspector Variables

    /// <summary>The avatar prefab.</summary>
    [Tooltip("The avatar prefab.")]
    [SerializeField] protected O8CActorParts avatarPrefab;

    /// <summary>The hot mic indicator prefab.</summary>
    [Tooltip("The hot mic indicator prefab.")]
    [SerializeField] protected GameObject hotMicIndicatorPrefab;

    /// <summary>The controllers prefab.</summary>
    [Tooltip("The controllsers prefab.")]
    [SerializeField] protected GameObject controllersPrefab;

    [SerializeField] MotorInput[] motorInputs;

    #endregion


    public override GameObject CreateAvatar(GameObject player, bool isLocalPlayer) {
        var networkPlayer = player.GetComponent<IO8CNetworkPlayer>();


        O8CActorParts avatar = Instantiate(avatarPrefab, player.transform);

        networkPlayer.AddHeadFollower(avatar.HeadRoot);
        networkPlayer.AddLeftHandFollower(avatar.LeftHandRoot);
        networkPlayer.AddRightHandFollower(avatar.RightHandRoot);

        if (isLocalPlayer) {
            player.AddComponent<StartSceneMicrophoneController>();
            var actorMotor = player.AddComponent<ActorMotorSimple>();
            foreach (var motorInput in motorInputs) {
                motorInput.SetMotor(actorMotor);
                motorInput.SetInputTransform(avatar.BodyJoint.transform);
            }
            O8CSystem.Instance.DeviceTracking.SetPlayAreaFollower(player);

            Instantiate(hotMicIndicatorPrefab, avatar.HeadRoot.transform);

            var controllers = Instantiate(controllersPrefab, player.transform).GetComponent<O8CActorParts>();
            networkPlayer.AddLeftHandFollower(controllers.LeftHandRoot);
            networkPlayer.AddRightHandFollower(controllers.RightHandRoot);
            ControllerDisplay controllerDisplay = controllers.gameObject.GetComponent<ControllerDisplay>();
            controllerDisplay.AvatarActorParts = avatar;
        }

        return avatar.gameObject;
    }

}
