using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviourPun
{
    [SerializeField] public GameObject projectilePrefab; // Prefab do projétil
    [SerializeField] public Transform firePoint; // Ponto onde o projétil será instanciado
    [SerializeField] public float fireRate = 1f; // Taxa de disparo
    private float nextFireTime = 0f; // Controla quando o tanque pode disparar novamente

    void Update()
    {
        if (photonView.IsMine && Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            photonView.RPC("ShootProjectile", RpcTarget.All, firePoint.position, firePoint.rotation);
        }
    }

    [PunRPC]
    void ShootProjectile(Vector3 position, Quaternion rotation)
    {
        // Instancia o projétil localmente para todos os jogadores
        GameObject projectile = Instantiate(projectilePrefab, position, rotation);

        // Se o projétil precisar ser sincronizado (com movimento e colisão), adicione o PhotonView
        PhotonView pv = projectile.GetComponent<PhotonView>();
        if (pv == null)
        {
            pv = projectile.AddComponent<PhotonView>();
            pv.ViewID = PhotonNetwork.AllocateViewID(true); // Garante que o projétil tenha um ID de rede único
        }
    }
}
