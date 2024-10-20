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
        if (photonView.IsMine)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Verifica se o botão de disparo (botão esquerdo do mouse) foi pressionado e se o tanque pode disparar
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Debug.Log("Disparando projétil!"); // Verifica se o disparo está sendo registrado
            // Instancia o projétil na posição do firePoint com a rotação da torreta
            PhotonView.Instantiate(projectilePrefab, firePoint.position, firePoint.rotation).GetComponent<Bala>();

            // Define o próximo momento em que o tanque poderá disparar, baseado na fireRate
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
