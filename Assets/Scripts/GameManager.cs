using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] public string tankPrefab; //Nome do prefab do tanque que ser� instanciado para cada jogador
    private List<GameObject> players = new List<GameObject>();  //Lista para rastrear os jogadores ativos no jogo


    void Start()
    {
        // Instancia o tanque quando o jogador se conecta
        PhotonNetwork.Instantiate(tankPrefab, Vector3.zero, Quaternion.identity, 0); //Faz com que o objeto seja sincronizado para todos os jogadores na sala.
    }


    public void RegisterPlayer(GameObject player) //M�todo para registrar um jogador na lista de jogadores
    {
        players.Add(player); //Adiciona o jogador � lista de jogadores ativos
    }

    public void UnregisterPlayer(GameObject player) //M�todo para remover um jogador da lista de jogadores
    {
        players.Remove(player); //Remove o jogador da lista de jogadores ativos
    }
}
