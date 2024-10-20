using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraTorreta : MonoBehaviour
{
    [SerializeField] private Transform turret; // A referência à torreta do tanque
    [SerializeField] private Camera mainCamera; // Referência à câmera principal do jogo

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Se não for atribuída, tenta pegar a câmera principal
        }
    }

    void Update()
    {
        RotateTurret();
    }

    void RotateTurret()
    {
        // Pega a posição do mouse em coordenadas de tela e converte para o mundo
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        // Calcula a direção para a qual a torreta deve apontar
        Vector3 direction = worldPosition - turret.position;
        direction.z = 0; // Como é um jogo 2D, garantimos que o eixo Z permaneça inalterado

        // Calcula o ângulo de rotação com base na direção e aplica na rotação da torreta
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        turret.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Ajusta para a rotação correta
    }
}

