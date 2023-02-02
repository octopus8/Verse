using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IO8CNetworkPlayer {
    void AddHeadFollower(GameObject head);
    void AddLeftHandFollower(GameObject leftHand);
    void AddRightHandFollower(GameObject rightHand);
    void RemoveHeadFollower(GameObject head);
    void RemoveLeftHandFollower(GameObject leftHand);
    void RemoveRightHandFollower(GameObject rightHand);
}
