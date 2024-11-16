using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tanque : MonoBehaviourPun
{
    public int health = 60; // Quantidade de vida do tanque
    public float moveSpeed = 5; // Velocidade de movimento do tanque.
    public float rotateSpeed = 200; // Velocidade de rota��o do tanque.

    void Update()
    {
        if (photonView.IsMine) // // Verifica se o tanque pertence ao jogador local antes de permitir o controle
        {
            Move(); // Utiliza o m�todo da interface
        }
    }

    public void Move()
    {
        // L�gica original da movimenta��o do tanque
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;  //Calcula a movimenta��o para frente ou para tr�s.
        float rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime; //Calcula a rota��o

        transform.Translate(0, move, 0);  //Move o tanque para frente ou para tr�s com base na entrada do jogador
        transform.Rotate(0, 0, -rotate); //Rotaciona o tanque com base na entrada do jogador
    }

    private void OnTriggerEnter2D(Collider2D collision) //M�todo chamado ao detectar uma colis�o com outro objeto.
    {
        if (collision.transform || collision.gameObject.tag == "Bala") //Verifica se o objeto colidido � v�lido ou se a tag corresponde a "Bala".
        {
            Debug.Log("Tanque atingido!"); //Mostra uma mensagem no console indicando que o tanque foi atingido
          
        }
    }
}
