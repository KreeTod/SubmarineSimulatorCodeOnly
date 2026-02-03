using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ServerNetworkCBBKR : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        // Проверяем, если это первый игрок
        if (numPlayers == 1)
        {
            // Переключаем камеру хоста на первого игрока
            conn.identity.GetComponentInChildren<Camera>().enabled = true; // Включаем камеру первого игрока
            conn.identity.GetComponentInChildren<AudioListener>().enabled = true;
            /*conn.identity.GetComponentInChildren<NetworkedBodyPosition>().enabled = true;
            conn.identity.GetComponentInChildren<Move>().enabled = true;
            conn.identity.GetComponentInChildren<Camera_movement>().enabled = true;
            conn.identity.GetComponentInChildren<Jump>().enabled = true;
            conn.identity.GetComponentInChildren<NetworkWeaponSlots>().enabled = true;*/
        }
        else
        {
            conn.identity.GetComponentInChildren<Camera>().enabled = false;
            conn.identity.GetComponentInChildren<AudioListener>().enabled = false;
            /*conn.identity.GetComponentInChildren<NetworkedBodyPosition>().enabled = false;
            conn.identity.GetComponentInChildren<Move>().enabled = false;
            conn.identity.GetComponentInChildren<Camera_movement>().enabled = false;
            conn.identity.GetComponentInChildren<Jump>().enabled = false;
            conn.identity.GetComponentInChildren<NetworkWeaponSlots>().enabled = false;*/

        }
    }

    // public GameObject playerPrefabbebra;
    /*
    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        base.OnServerConnect(conn);
        // Создаем игрока на сервере
        GameObject playerbebra = Instantiate(playerPrefabbebra);

        // Заспавниваем игрока на всех клиентах
        NetworkServer.Spawn(playerbebra, conn);
    }*/

}
