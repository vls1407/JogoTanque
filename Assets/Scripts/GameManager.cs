using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] public string tankPrefab;
    private List<GameObject> players = new List<GameObject>();


    void Start()
    {
        // Instancia o tanque quando o jogador se conecta
        PhotonNetwork.Instantiate(tankPrefab, Vector3.zero, Quaternion.identity, 0);
    }

    [PunRPC]
    public void PlayerDied(int playerId)
    {
        // Lógica para quando um jogador morre
    }

    public void RegisterPlayer(GameObject player)
    {
        players.Add(player);
    }

    public void UnregisterPlayer(GameObject player)
    {
        players.Remove(player);
    }
}
