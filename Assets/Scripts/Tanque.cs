using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tanque : MonoBehaviourPun
{
    public int health = 60;
    public float moveSpeed = 5;
    public float rotateSpeed = 200;

    void Update()
    {
        if (photonView.IsMine)
        {
            Move(); // Utiliza o m�todo da interface
        }
    }

    public void Move()
    {
        // L�gica original da movimenta��o do tanque
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(0, move, 0);
        transform.Rotate(0, 0, -rotate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform || collision.gameObject.tag == "Bala")
        {
            Debug.Log("Tanque atingido!");
            // L�gica de dano (placeholder)
        }
    }
}






/*public class Tanque : MonoBehaviourPun
{
    public int health = 60;
    public float moveSpeed = 5;
    public float rotateSpeed = 200;

    void Update()
    {
        if (photonView.IsMine)
        {
            MoveTank();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     if (collision.transform || collision.gameObject.tag == "Bala") 
     {
            Debug.Log("colis�o entrou");
            TakeDamage(10); 
     }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Notifica o GameManager que o jogador morreu
            photonView.RPC("PlayerDied", RpcTarget.All);
           
        }
    }

    [PunRPC]
    public void PlayerDied()
    {
        Destroy(gameObject); // Destr�i o tanque
    }




    private void MoveTank()
    {
        // Captura entrada do jogador
        float moveInput = Input.GetAxis("Vertical"); // W/S ou setas para cima/baixo
        float rotateInput = Input.GetAxis("Horizontal"); // A/D ou setas esquerda/direita

        // Movimenta��o
        Vector3 moveDirection = transform.up * moveInput * moveSpeed * Time.deltaTime;
        transform.position += moveDirection;

        // Rota��o
        float rotationAmount = rotateInput * rotateSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -rotationAmount);
    }



}*/
