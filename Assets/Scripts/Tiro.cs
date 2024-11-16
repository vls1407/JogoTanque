using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviourPun
{
    [SerializeField] public GameObject projectilePrefab; // Prefab do proj�til
    [SerializeField] public Transform firePoint; // Ponto onde o proj�til ser� instanciado
    [SerializeField] public float fireRate = 1f; // Taxa de disparo
    private float nextFireTime = 0f; // Controla quando o tanque pode disparar novamente

    void Update()
    {
        if (photonView.IsMine && Input.GetMouseButton(0) && Time.time >= nextFireTime) //Verifica se este objeto pertence ao jogador local no multiplayer 
        {
            nextFireTime = Time.time + 1f / fireRate; //Atualiza o tempo para o pr�ximo disparo com base no fireRate
            photonView.RPC("ShootProjectile", RpcTarget.All, firePoint.position, firePoint.rotation); //Chama o m�todo ShootProjectile para sincronizar o disparo em todos os jogadores
        }
    }

    [PunRPC]
    void ShootProjectile(Vector3 position, Quaternion rotation) //M�todo RPC respons�vel por criar e disparar o proj�til.
    {
        // Instancia o proj�til localmente para todos os jogadores
        GameObject projectile = Instantiate(projectilePrefab, position, rotation);

        // Se o proj�til precisar ser sincronizado (com movimento e colis�o), adicione o PhotonView
        PhotonView pv = projectile.GetComponent<PhotonView>();
        if (pv == null)
        {
            pv = projectile.AddComponent<PhotonView>();
            pv.ViewID = PhotonNetwork.AllocateViewID(true); // Garante que o proj�til tenha um ID de rede �nico
        }
    }
}
