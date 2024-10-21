using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviourPun
{
    public int health = 100;
    public float moveSpeed = 5;
    public float rotateSpeed = 200;

    void Update()
    {
        if (photonView.IsMine)
        {
            MoveTank();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Notifica o GameManager que o jogador morreu
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("PlayerDied", RpcTarget.All, photonView.ViewID);
            PhotonView.Destroy(gameObject); // Destrói o tanque
        }
    }

    private void MoveTank()
    {
        // Captura entrada do jogador
        float moveInput = Input.GetAxis("Vertical"); // W/S ou setas para cima/baixo
        float rotateInput = Input.GetAxis("Horizontal"); // A/D ou setas esquerda/direita

        // Movimentação
        Vector3 moveDirection = transform.up * moveInput * moveSpeed * Time.deltaTime;
        transform.position += moveDirection;

        // Rotação
        float rotationAmount = rotateInput * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotationAmount);
    }



}
