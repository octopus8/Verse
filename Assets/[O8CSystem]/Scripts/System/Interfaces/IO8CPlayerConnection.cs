
using System;
using UnityEngine;

namespace O8C.System {


    public interface IO8CPlayerConnection {

        public void AddPlayerConnectedObserver(Action<GameObject, bool> observer);

        public void RemovePlayerConnectedObserver(Action<GameObject, bool> observer);

        public void PlayerConnected(GameObject player, bool isLocalPlayer);

        public void PlayerDisconnected(GameObject player, bool isLocalPlayer);

    }

}