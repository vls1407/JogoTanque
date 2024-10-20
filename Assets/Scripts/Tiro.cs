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
        if (photonView.IsMine)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Verifica se o bot�o de disparo (bot�o esquerdo do mouse) foi pressionado e se o tanque pode disparar
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Debug.Log("Disparando proj�til!"); // Verifica se o disparo est� sendo registrado
            // Instancia o proj�til na posi��o do firePoint com a rota��o da torreta
            PhotonView.Instantiate(projectilePrefab, firePoint.position, firePoint.rotation).GetComponent<Bala>();

            // Define o pr�ximo momento em que o tanque poder� disparar, baseado na fireRate
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
